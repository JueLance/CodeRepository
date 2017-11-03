import java.io.IOException;
import java.net.URL;
import java.util.Enumeration;

public class App {


    public static void main(String[] args) {
        ClassLoader sysLoader = ClassLoader.getSystemClassLoader();

        System.out.println("系统类加载器：" + sysLoader);//系统类加载器：sun.misc.Launcher$AppClassLoader@18b4aac2
//file:/D:/WorkSpace/gitcode/github/CodeRepository/Java/JavaLang/ClassLoaderSample/target/classes/
        //系统类的加载器是程序运行的当前路径

        Enumeration<URL> eml = null;
        try {
            eml = sysLoader.getResources("");
        } catch (IOException e) {
            e.printStackTrace();
        }

        while (eml.hasMoreElements()) {
            System.out.println(eml.nextElement());
        }

        ClassLoader extensionLoader = sysLoader.getParent();
        System.out.println("拓展类加载器：" + extensionLoader);//拓展类加载器：sun.misc.Launcher$ExtClassLoader@1540e19d

        System.out.println("拓展类加载器的加载路径：" + System.getProperty("java.ext.dirs"));//拓展类加载器的加载路径：C:\Program Files\Java\jdk1.8.0_131\jre\lib\ext;C:\WINDOWS\Sun\Java\lib\ext

        System.out.println("拓展类加载器的parent:" + extensionLoader.getParent());//拓展类加载器的parent:null
//这里拓展类加载器的父加载器是null，并不是根类加载器。这是因为根类加载器并没有继承ClassLoader抽象类，所以拓展类加载器的getParent()方法返回null。
        //实际上，拓展类加载器的父类加载器是根类加载器，只是根类加载器并不是Java实现的。
    }

}
