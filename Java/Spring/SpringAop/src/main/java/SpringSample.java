
import java.text.SimpleDateFormat;
import java.util.Calendar;

import cn.rocky.Production;
import cn.rocky.SayHello;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.beans.factory.xml.XmlBeanFactory;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.core.io.ClassPathResource;

public class SpringSample {

    public static void main(String[] args) {
        springDemo1();
    }

    private void test() {
        //从配置文件中获取已经配置的Bean
        BeanFactory factory = new XmlBeanFactory(new ClassPathResource("application-context.xml"));
        SayHello hello = (SayHello) factory.getBean("hello");
        hello.greet();

        System.out.println("Hello World!");
    }

    private static void springDemo1() {

        ApplicationContext context = new ClassPathXmlApplicationContext(new String[]{"spring-config.xml"});

        // 通过构造器创建一个bean实例
        Production hello2 = context.getBean("product", Production.class);
        System.out.println(hello2.getName());

        ((ClassPathXmlApplicationContext) context).close();

    }

    private void test2() {

        ApplicationContext context = new ClassPathXmlApplicationContext(new String[]{"spring-config.xml"});

        // 通过工厂方法创建一个bean实例
        Calendar calendar = context.getBean("staticDate", Calendar.class);
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");

        ((ClassPathXmlApplicationContext) context).close();

        System.out.println(format.format(calendar.getTime()));
    }
}

