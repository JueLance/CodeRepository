package cn.rocky.CustomAnnotation;

public class ClassWithMyAnnotation {

    //当注解中使用的属性名为value时，对其赋值时可以不指定属性的名称而直接写上属性值接口；
    //除了value意外的变量名都需要使用name=value的方式赋值。
    @MyAnnotation(value = "wwww", name = "121212", value2 = MyEnum.Rainy, values = {"a", "b"})
    public void execute() {
        System.out.println("ClassWithMyAnnotation executed.");

    }
}
