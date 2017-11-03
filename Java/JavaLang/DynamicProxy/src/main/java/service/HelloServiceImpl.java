package service;

public class HelloServiceImpl implements HelloService {
    @Override
    public void sayHello(String str) {
        System.out.println("实际执行的逻辑: " + str);
    }
}
