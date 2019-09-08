package cn.rocky.datatype;

import redis.clients.jedis.BinaryClient;
import redis.clients.jedis.Jedis;

import java.util.List;

public class ListDemo {
    /**
     * jedis操作List
     */
    public void run() {

        // 连接redis服务器，127.0.0.1:6379
        Jedis jedis = new Jedis("127.0.0.1", 6379);
        // 权限认证
        // jedis.auth("admin");

        // 开始前，先移除所有的内容
        jedis.del("java framework");

        System.out.println(jedis.lrange("java framework", 0, -1));
        System.out.println();

        // 先向key java framework中存放三条数据
        jedis.lpush("java framework", "spring");
        jedis.lpush("java framework", "struts");
        jedis.lpush("java framework", "hibernate");
        // 再取出所有数据jedis.lrange是按范围取出，
        // 第一个是key，第二个是起始位置，第三个是结束位置，jedis.llen获取长度 -1表示取得所有
        System.out.println(jedis.lrange("java framework", 0, -1));

        System.out.println();

        jedis.del("java framework");
        jedis.rpush("java framework", "spring");
        jedis.rpush("java framework", "struts");
        jedis.rpush("java framework", "hibernate");
        System.out.println(jedis.lrange("java framework", 0, -1));
        jedis.close();
    }

    void sss(){

        Jedis jedis = new Jedis("127.0.0.1", 6379);

        System.out.println("==List==");
        // 清空数据
        System.out.println(jedis.flushDB());
        //添加数据
        jedis.rpush("names", "唐僧");
        jedis.rpush("names", "悟空");
        jedis.rpush("names", "八戒");
        jedis.rpush("names", "悟净");
        // 再取出所有数据jedis.lrange是按范围取出，
        // 第一个是key，第二个是起始位置，第三个是结束位置，jedis.llen获取长度 -1表示取得所有
        List<String> values = jedis.lrange("names", 0, -1);
        System.out.println(values);


        // 清空数据
        System.out.println(jedis.flushDB());
        // 添加数据
        jedis.lpush("scores", "100");
        jedis.lpush("scores", "99");
        jedis.lpush("scores", "55");
        // 数组长度
        System.out.println(jedis.llen("scores"));
        // 排序
        System.out.println(jedis.sort("scores"));
        // 字串
        System.out.println(jedis.lrange("scores", 0, 3));
        // 修改列表中单个值
        jedis.lset("scores", 0, "66");
        // 获取列表指定下标的值
        System.out.println(jedis.lindex("scores", 1));
        // 删除列表指定下标的值
        System.out.println(jedis.lrem("scores", 1, "99"));
        // 删除区间以外的数据
        System.out.println(jedis.ltrim("scores", 0, 1));
        // 列表出栈
        System.out.println(jedis.lpop("scores"));
        // 整个列表值
        System.out.println(jedis.lrange("scores", 0, -1));
        //在100之前添加数据数据
        jedis.linsert("scores", BinaryClient.LIST_POSITION.BEFORE, "100", "22");
        //在100之后添加数据数据
        jedis.linsert("scores", BinaryClient.LIST_POSITION.AFTER, "100", "77");
        // 整个列表值
        System.out.println(jedis.lrange("scores", 0, -1));
        //把List中key为scores的第二条数据改为88
        jedis.lset("scores", 1, "88");
        // 整个列表值
        System.out.println(jedis.lrange("scores", 0, -1));
        //截取列表区间内的元素
        jedis.ltrim("scores", 1, 2);
        // 整个列表值
        System.out.println(jedis.lrange("scores", 0, -1));
        //将值 value 插入到列表 key 的表尾，当且仅当 key 存在并且是一个列表。当 key 不存在时， RPUSHX 命令什么也不做。
        jedis.rpushx("name", "Alex");
        System.out.println(jedis.lrange("name", 0, -1));
    }
}
