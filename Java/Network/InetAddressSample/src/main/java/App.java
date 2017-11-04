import java.net.InetAddress;

public class App {
    public static void main(String[] args) throws Exception {
        InetAddress ip = InetAddress.getByName("www.baidu.com");
        System.out.println("网址是否可以连接：" + ip.isReachable(2000));
        System.out.println("www.baidu.com的主机名：" + ip.getHostAddress());

        InetAddress local = InetAddress.getByAddress(new byte[]{127, 0, 0, 1});
        System.out.println("本机是否可达：" + local.isReachable(2000));
        System.out.println("全限定域名：" + local.getCanonicalHostName());

    }
}
