package cn.rocky;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class TestJni {

    public native void myPrint();

    static {
        // 依赖于这个路径System.getProperty("java.library.path")
        System.out.println("java.library.path: " + System.getProperty("java.library.path"));
        System.loadLibrary("hellow");
        // 动态链接库的名字(linux下对应为libhellow.so)
    }

    public static void main(String args[]) {
        // System.out.println(System.getProperty("java.library.path"));
        TestJni test = new TestJni();
        test.myPrint();// 调用hellow动态链接库中的myPrint()方法

        System.out.println();

        NativeMethodTest methodTest = new NativeMethodTest();

        System.out.println("intMethod:" + methodTest.intMethod(20));

        System.out.println("booleanMethod: " + methodTest.booleanMethod(false));

        System.out.println("stringMethod: " + methodTest.stringMethod("中文 & English"));

        int[] intArr = methodTest.intArrayMethod(new int[]{1, 2, 3, 4, 5});

        System.out.println("====================intArrayMethod====================");
        if (intArr != null && intArr.length > 0) {

            for (int i = 0; i < intArr.length; i++) {
                System.out.println(intArr[i]);
            }
        }

        System.out.println("====================intArrayMethod====================");
        //new Long[] { 1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L, 9L, 0L }
        Long longArr = methodTest.longMethod(10L);

        System.out.println("longMethod: " + longArr);

        System.out.println("====================stringArrayMethod====================");

        String[] stringArr = methodTest.stringArrayMethod(new String[]{"一", "二", "三", "One", "Two", "Three"});

        if (stringArr != null && stringArr.length > 0) {

            for (int i = 0; i < stringArr.length; i++) {
                System.out.println(stringArr[i]);
            }
        }

        System.out.println("====================stringArrayMethod====================");

        People[] peoples = new People[2];
        peoples[0] = new People(1, "朱子成", Calendar.getInstance().getTime());
        peoples[1] = new People(2, "JueLance", Calendar.getInstance().getTime());

        methodTest.objectMethod(peoples);

        List<People> list = new ArrayList<>();
        list.add(new People(1, "朱子成", Calendar.getInstance().getTime()));
        list.add(new People(2, "JueLance", Calendar.getInstance().getTime()));

        List<People> list2 = methodTest.objectArrayMethod(list);
        System.out.println("====================objectArrayMethod====================");
        if (list2 != null && list2.size() > 0) {

            for (People people : list2) {
                System.out.println(people);
            }
        }

        System.out.println("====================objectArrayMethod====================");

    }
}
