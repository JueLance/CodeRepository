package cn.rocky;

import redis.clients.jedis.Jedis;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

public class RedisSample {

    public static void main(String[] args) {


        // 连接redis服务器，127.0.0.1:6379
        Jedis jedis = new Jedis("127.0.0.1", 6379, 1000);

        // 权限认证
        //jedis.auth"admin");
        // jedis 排序
        // 注意，此处的rpush和lpush是List的操作。是一个双向链表（但从表现来看的）
//        jedis.del("list");// 先清除数据，再加入数据进行测试
//
//
//        System.out.println(refFormatNowDate());
//
//        for (int i = 0; i < 10000000; i++) {
//
//            jedis.lpush("list", String.valueOf(i));
//        }
        jedis.lpush("list2", String.valueOf(2222));

        List<String> sss = jedis.lrange("list2", 0L, -1);

        System.out.println(sss);

        jedis.close();

        System.out.println(refFormatNowDate());
    }

    public static String refFormatNowDate() {
        Date nowTime = new Date(System.currentTimeMillis());
        SimpleDateFormat sdFormatter = new SimpleDateFormat("yyyy-MM-dd hh:mm:dd.sss");
        String retStrFormatNowDate = sdFormatter.format(nowTime);
        return retStrFormatNowDate;
    }

    public static void test() {

        // 连接redis服务器，127.0.0.1:6379
        Jedis jedis = new Jedis("127.0.0.1", 6379);
        // 权限认证
        //jedis.auth"admin");
        // jedis 排序
        // 注意，此处的rpush和lpush是List的操作。是一个双向链表（但从表现来看的）
        jedis.del("a");// 先清除数据，再加入数据进行测试
        jedis.rpush("a", "1");
        jedis.lpush("a", "6");
        jedis.lpush("a", "3");
        jedis.lpush("a", "9");
        System.out.println(jedis.lrange("a", 0, -1));// [9, 3, 6, 1]
        System.out.println(jedis.sort("a")); // [1, 3, 6, 9] //输入排序后结果
        System.out.println(jedis.lrange("a", 0, -1));

        jedis.close();
    }


}