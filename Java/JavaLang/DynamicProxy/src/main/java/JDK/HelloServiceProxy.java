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

    /**
     * 执行动态代理对象的所有方法时，都会被替换成执行如下的Invoke()方法
     * proxy:代表动态代理对象
     * method: 代表正在执行的方法
     * args:代表调用目标方法时传入的实参
     ***/
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
