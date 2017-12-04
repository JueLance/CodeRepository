package cn.rocky;

public class SayHello {
    private String name;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void greet(){
        System.out.println("Hello, "+name);
    }

}
