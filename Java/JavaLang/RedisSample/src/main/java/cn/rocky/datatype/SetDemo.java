package cn.rocky.datatype;

import redis.clients.jedis.Jedis;

public class SetDemo {


    /**
     * jedis操作Set
     */
    public void run() {

        // 连接redis服务器，127.0.0.1:6379
        Jedis jedis = new Jedis("127.0.0.1", 6379);
        // 权限认证
        // jedis.auth("admin");

        jedis.del("user");

        // 添加
        jedis.sadd("user", "liuling");
        jedis.sadd("user", "xinxin");
        jedis.sadd("user", "ling");
        jedis.sadd("user", "zhangxinxin");
        jedis.sadd("user", "who");
        // 移除noname
        jedis.srem("user", "who");

        System.out.println(jedis.smembers("user"));// 获取所有加入的value
        System.out.println(jedis.sismember("user", "who"));// 判断 who
        // 是否是user集合的元素
        System.out.println(jedis.srandmember("user"));
        System.out.println(jedis.scard("user"));// 返回集合的元素个数
        jedis.close();
    }
}
