package JDK;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;

public class HelloServiceProxy implements InvocationHandler {

    private Object realObj;


    public Object bind(Object target) {

        this.realObj = target;
        return Proxy.newProxyInstance(realObj.getClass().getClassLoader(), realObj.getClass().getInterfaces(), this);
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        System.err.println("JDK动态代理里面的invoke方法");
        Object result = null;

        System.err.println("调用真实对象的方法之前的逻辑");

        result = method.invoke(realObj, args);


        System.err.println("调用真实对象的方法之后");


        return result;
    }
}
