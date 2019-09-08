package cn.rocky.datatype;

import redis.clients.jedis.Jedis;

import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

public class MapDemo {
    /**
     * redis操作Map
     */
    public void run() {

        // 连接redis服务器，127.0.0.1:6379
        Jedis jedis = new Jedis("127.0.0.1", 6379);
        // 权限认证
        // jedis.auth("admin");
        // -----添加数据----------
        Map<String, String> map = new HashMap<String, String>();
        map.put("name", "xinxin");
        map.put("age", "22");
        map.put("qq", "123456");
        jedis.hmset("user", map);
        // 取出user中的name，执行结果:[minxr]-->注意结果是一个泛型的List
        // 第一个参数是存入redis中map对象的key，后面跟的是放入map中的对象的key，后面的key可以跟多个，是可变参数
        List<String> rsmap = jedis.hmget("user", "name", "age", "qq");
        System.out.println(rsmap);

        System.out.println();

        // 删除map中的某个键值
        jedis.hdel("user", "age");
        System.out.println("age:" + jedis.hmget("user", "age")); // 因为删除了，所以返回的是null
        System.out.println("hlen:" + jedis.hlen("user")); // 返回key为user的键中存放的值的个数2
        System.out.println("exists:" + jedis.exists("user"));// 是否存在key为user的记录
        // 返回true
        System.out.println("hkeys:" + jedis.hkeys("user"));// 返回map对象中的所有key
        System.out.println("hvals:" + jedis.hvals("user"));// 返回map对象中的所有value

        System.out.println();

        Iterator<String> iter = jedis.hkeys("user").iterator();
        while (iter.hasNext()) {
            String key = iter.next();
            System.out.println(key + ":" + jedis.hmget("user", key));
        }

        jedis.close();
    }
}
