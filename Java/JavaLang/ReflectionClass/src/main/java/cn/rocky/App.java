package cn.rocky;

import cn.rocky.CustomAnnotation.ClassWithMyAnnotation;
import cn.rocky.CustomAnnotation.MyAnnotation;
import org.junit.Test;

import java.lang.annotation.Annotation;
import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.List;

public class App {


    @SuppressWarnings({"unchecked", "rawtypes"})
    public static void main(String[] args) {
        Parent c = new Child();
        List<SortableField> list = c.init();//获取泛型中类里面的注解
        //输出结果
        for (SortableField l : list) {
            System.out.println("字段名称：" + l.getName() + "\n字段类型：" + l.getType() + "\n注解名称：" + l.getMeta().name() + "\n注解描述：" + l.getMeta().description() + "\n\n");
        }
    }

    @Test
    public void testReflect() {
        Class<UserInfo> fyBasicInfoDtoClass = UserInfo.class;
        Field[] fields = fyBasicInfoDtoClass.getDeclaredFields();
        for (Field field : fields) {
            //if (field.getModifiers() == Modifier.PRIVATE)
            System.out.println(field.getType().getSimpleName() + " " + field.getName());
        }
    }

    @Test
    public void testRec() throws SecurityException, NoSuchMethodException, IllegalArgumentException, IllegalAccessException, InvocationTargetException {
        ClassWithMyAnnotation annotationTest2 = new ClassWithMyAnnotation();
        //获取AnnotationTest2的Class实例
        Class<ClassWithMyAnnotation> c = ClassWithMyAnnotation.class;
        //获取需要处理的方法Method实例
        Method method = c.getMethod("execute", new Class[]{});
        //判断该方法是否包含MyAnnotation注解
        if (method.isAnnotationPresent(MyAnnotation.class)) {
            //获取该方法的MyAnnotation注解实例
            MyAnnotation myAnnotation = method.getAnnotation(MyAnnotation.class);
            //执行该方法
            method.invoke(annotationTest2, new Object[]{});
            //获取myAnnotation
            String[] value1 = myAnnotation.values();
            System.out.println(value1[0]);
        }
        //获取方法上的所有注解
        Annotation[] annotations = method.getAnnotations();
        for (Annotation annotation : annotations) {
            System.out.println(annotation);
        }
    }
}
