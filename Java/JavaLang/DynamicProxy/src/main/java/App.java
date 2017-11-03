import Cglib.HelloServiceCgLib;
import service.HelloService;
import service.HelloServiceImpl;
import JDK.HelloServiceProxy;

public class App {
    public static void main(String[] args) {

        //System.out与System.err.
        //2者分别是同步的:
        //如果仅使用其中一种.那么先运行的代码先输出,后运行的代码后输出.但如果2这混用   如:
        //System.out.print("1");
        //System.err.print("2");
        //那么1与2的顺序理论上是不固定的.System.out与System.err两者是不同步的.他们的顺序基于cpu的调度
        HelloServiceProxy helloHandler = new HelloServiceProxy();
        HelloService proxy = (HelloService) helloHandler.bind(new HelloServiceImpl());
        proxy.sayHello("张三");


        HelloServiceCgLib cgLib = new HelloServiceCgLib();
        HelloService cgProxy = (HelloService) cgLib.getInstance(new HelloServiceImpl());
        cgProxy.sayHello("李四");
    }
}
