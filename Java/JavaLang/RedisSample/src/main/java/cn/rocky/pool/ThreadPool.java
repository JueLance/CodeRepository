package cn.rocky.pool;

public class ThreadPool {

    public static void testRedisPool() {

        RedisUtil.getJedis().set("newname", "中文测试");
        System.out.println(RedisUtil.getJedis().get("newname"));
    }
}
