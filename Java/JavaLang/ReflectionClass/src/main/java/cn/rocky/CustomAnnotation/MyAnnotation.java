package cn.rocky.CustomAnnotation;


import java.lang.annotation.*;

@Documented
//注释保留策略。此枚举类型的常量描述保留注释的不同策略。它们与 Retention 元注释类型一起使用，以指定保留多长的注释。
/**
 * CLASS
 编译器将把注释记录在类文件中，但在运行时 VM 不需要保留注释。
 RUNTIME
 编译器将把注释记录在类文件中，在运行时 VM 将保留注释，因此可以反射性地读取。
 SOURCE
 编译器要丢弃的注释。

 @Retention注解可以在定义注解时为编译程序提供注解的保留策略。 属于CLASS保留策略的注解有@SuppressWarnings，该注解信息不会存储于.class文件。


  * **/
@Retention(RetentionPolicy.RUNTIME)
//只有元注释类型直接用于注释时，Target 元注释才有效。如果元注释类型用作另一种注释类型的成员，则无效。
//@Target(value = ElementType.ANNOTATION_TYPE)
@Target(value = ElementType.METHOD)
public @interface MyAnnotation {

    //在注解中添加变量
    String value();

    String name() default "JueLance";//给name添加默认值

    //使用枚举
    MyEnum value2() default MyEnum.Sunny;

    //使用数组
    String[] values() default "abc";

}

enum MyEnum {
    Sunny,
    Rainy
}
