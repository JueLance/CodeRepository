package cn.rocky;

import java.util.List;

public class NativeMethodTest {
    public native int intMethod(int n);

    public native boolean booleanMethod(boolean bool);

    public native String stringMethod(String text);

    public native int[] intArrayMethod(int[] arr);

    public native Long longMethod(Long value);

    public native String[] stringArrayMethod(String[] arr);

    public native People objectMethod(People[] arr);

    public native List<People> objectArrayMethod(List<People> arr);

}
