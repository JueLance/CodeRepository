class TestJni{
    public native void myPrint();
    static{
        System.loadLibrary("hellow");
        //动态链接库的名字(linux下对应为libhellow.so)
    }
    public static void main(String args[]){
        //System.out.println(System.getProperty("java.library.path"));
        TestJni test = new TestJni();
        test.myPrint();//调用hellow动态链接库中的myPrint()方法
    }
}
