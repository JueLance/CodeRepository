//http://www.cnblogs.com/yangecnu/p/Introduct-Redis-in-DotNET-Part2.html

/*


http://www.cnblogs.com/caokai520/p/4409712.html
http://www.cnblogs.com/lulu/archive/2013/06/10/3130878.html
http://qifuguang.me/2015/09/29/Redis%E4%BA%94%E7%A7%8D%E6%95%B0%E6%8D%AE%E7%B1%BB%E5%9E%8B%E4%BB%8B%E7%BB%8D/
http://www.cnblogs.com/yangecnu/default.html?page=2

*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.Redis;
using NUnit.Framework;
using ServiceStack.Text;
using ServiceStack;

namespace UnitTestProject1
{
    [TestFixture, Explicit, Category("Integration")]
    public class BlogPostExample
    {
        readonly RedisClient redis = new RedisClient("localhost");

        [SetUp]
        public void OnBeforeEachTest()
        {
            redis.FlushAll();
            InsertTestData();
        }

        public void InsertTestData()
        {
            var redisUsers = redis.As<User>();
            var redisBlogs = redis.As<Blog>();
            var redisBlogPosts = redis.As<BlogPost>();

            var yangUser = new User { Id = redisUsers.GetNextSequence(), Name = "Eric Yang" };
            var zhangUser = new User { Id = redisUsers.GetNextSequence(), Name = "Fish Zhang" };

            var yangBlog = new Blog
            {
                Id = redisBlogs.GetNextSequence(),
                UserId = yangUser.Id,
                UserName = yangUser.Name,
                Tags = new List<string> { "Architecture", ".NET", "Databases" },
            };

            var zhangBlog = new Blog
            {
                Id = redisBlogs.GetNextSequence(),
                UserId = zhangUser.Id,
                UserName = zhangUser.Name,
                Tags = new List<string> { "Architecture", ".NET", "Databases" },
            };

            var blogPosts = new List<BlogPost>
    {
        new BlogPost
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = yangBlog.Id,
            Title = "Memcache",
            Categories = new List<string> { "NoSQL", "DocumentDB" },
            Tags = new List<string> {"Memcache", "NoSQL", "JSON", ".NET"} ,
            Comments = new List<BlogPostComment>
            {
                new BlogPostComment { Content = "First Comment!", CreatedDate = DateTime.UtcNow,},
                new BlogPostComment { Content = "Second Comment!", CreatedDate = DateTime.UtcNow,},
            }
        },
        new BlogPost
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = zhangBlog.Id,
            Title = "Redis",
            Categories = new List<string> { "NoSQL", "Cache" },
            Tags = new List<string> {"Redis", "NoSQL", "Scalability", "Performance"},
            Comments = new List<BlogPostComment>
            {
                new BlogPostComment { Content = "First Comment!", CreatedDate = DateTime.UtcNow,}
            }
        },
        new BlogPost
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = yangBlog.Id,
            Title = "Cassandra",
            Categories = new List<string> { "NoSQL", "Cluster" },
            Tags = new List<string> {"Cassandra", "NoSQL", "Scalability", "Hashing"},
            Comments = new List<BlogPostComment>
            {
                new BlogPostComment { Content = "First Comment!", CreatedDate = DateTime.UtcNow,}
            }
        },
        new BlogPost
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = zhangBlog.Id,
            Title = "Couch Db",
            Categories = new List<string> { "NoSQL", "DocumentDB" },
            Tags = new List<string> {"CouchDb", "NoSQL", "JSON"},
            Comments = new List<BlogPostComment>
            {
                new BlogPostComment {Content = "First Comment!", CreatedDate = DateTime.UtcNow,}
            }
        },
    };

            yangUser.BlogIds.Add(yangBlog.Id);
            yangBlog.BlogPostIds.AddRange(blogPosts.Where(x => x.BlogId == yangBlog.Id).Map(x => x.Id));

            zhangUser.BlogIds.Add(zhangBlog.Id);
            zhangBlog.BlogPostIds.AddRange(blogPosts.Where(x => x.BlogId == zhangBlog.Id).Map(x => x.Id));

            redisUsers.Store(yangUser);
            redisUsers.Store(zhangUser);
            redisBlogs.StoreAll(new[] { yangBlog, zhangBlog });
            redisBlogPosts.StoreAll(blogPosts);
        }

        [Test]
        public void Show_a_list_of_blogs()
        {
            var redisBlogs = redis.As<Blog>();
            var blogs = redisBlogs.GetAll();
            blogs.PrintDump();
        }

        [Test]
        public void Show_a_list_of_recent_posts_and_comments()
        {
            //Get strongly-typed clients
            var redisBlogPosts = redis.As<BlogPost>();
            var redisComments = redis.As<BlogPostComment>();
            {
                //To keep this example let's pretend this is a new list of blog posts
                var newIncomingBlogPosts = redisBlogPosts.GetAll();

                //Let's get back an IList<BlogPost> wrapper around a Redis server-side List.
                var recentPosts = redisBlogPosts.Lists["urn:BlogPost:RecentPosts"];
                var recentComments = redisComments.Lists["urn:BlogPostComment:RecentComments"];

                foreach (var newBlogPost in newIncomingBlogPosts)
                {
                    //Prepend the new blog posts to the start of the 'RecentPosts' list
                    recentPosts.Prepend(newBlogPost);

                    //Prepend all the new blog post comments to the start of the 'RecentComments' list
                    newBlogPost.Comments.ForEach(recentComments.Prepend);
                }

                //Make this a Rolling list by only keep the latest 3 posts and comments
                recentPosts.Trim(0, 2);
                recentComments.Trim(0, 2);

                //Print out the last 3 posts:
                recentPosts.GetAll().PrintDump();
                recentComments.GetAll().PrintDump();
            }
        }

        [Test]
        public void Show_a_TagCloud()
        {
            //Get strongly-typed clients
            var redisBlogPosts = redis.As<BlogPost>();
            var newIncomingBlogPosts = redisBlogPosts.GetAll();

            foreach (var newBlogPost in newIncomingBlogPosts)
            {
                //For every tag in each new blog post, increment the number of times each Tag has occurred 
                newBlogPost.Tags.ForEach(x =>
                    redis.IncrementItemInSortedSet("urn:TagCloud", x, 1));
            }

            //Show top 5 most popular tags with their scores
            var tagCloud = redis.GetRangeWithScoresFromSortedSetDesc("urn:TagCloud", 0, 4);
            tagCloud.PrintDump();
        }

        [Test]
        public void Show_all_Categories()
        {
            var redisBlogPosts = redis.As<BlogPost>();
            var blogPosts = redisBlogPosts.GetAll();

            foreach (var blogPost in blogPosts)
            {
                blogPost.Categories.ForEach(x =>
                        redis.AddItemToSet("urn:Categories", x));
            }

            var uniqueCategories = redis.GetAllItemsFromSet("urn:Categories");
            uniqueCategories.PrintDump();
        }

        [Test]
        public void Show_post_and_all_comments()
        {
            //There is nothing special required here as since comments are Key Value Objects 
            //they are stored and retrieved with the post
            var postId = 1;
            var redisBlogPosts = redis.As<BlogPost>();
            var selectedBlogPost = redisBlogPosts.GetById(postId.ToString());

            selectedBlogPost.PrintDump();
        }

        [Test]
        public void Add_comment_to_existing_post()
        {
            var postId = 1;
            var redisBlogPosts = redis.As<BlogPost>();
            var blogPost = redisBlogPosts.GetById(postId.ToString());
            blogPost.Comments.Add(
                new BlogPostComment { Content = "Third Post!", CreatedDate = DateTime.UtcNow });
            redisBlogPosts.Store(blogPost);

            var refreshBlogPost = redisBlogPosts.GetById(postId.ToString());
            refreshBlogPost.PrintDump();
        }

        [Test]
        public void Show_all_Posts_for_the_DocumentDB_Category()
        {
            var redisBlogPosts = redis.As<BlogPost>();
            var newIncomingBlogPosts = redisBlogPosts.GetAll();

            foreach (var newBlogPost in newIncomingBlogPosts)
            {
                //For each post add it's Id into each of it's 'Cateogry > Posts' index
                newBlogPost.Categories.ForEach(x =>
                        redis.AddItemToSet("urn:Category:" + x, newBlogPost.Id.ToString()));
            }

            //Retrieve all the post ids for the category you want to view
            var documentDbPostIds = redis.GetAllItemsFromSet("urn:Category:DocumentDB");

            //Make a batch call to retrieve all the posts containing the matching ids 
            //(i.e. the DocumentDB Category posts)
            var documentDbPosts = redisBlogPosts.GetByIds(documentDbPostIds);

            documentDbPosts.PrintDump();
        }
    }
}
