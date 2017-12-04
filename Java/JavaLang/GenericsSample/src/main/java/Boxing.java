import org.omg.CORBA.IntHolder;

public class Boxing {

    public void run() {
        int i = 20;
        IntHolder value = new IntHolder(20);
        triple(value);
        System.out.println(i);
        System.out.println(value.value);
    }

    // Java是值传递，参数的数据无法修改
    // public static void triple(int x) {
    // x = 3 * x;
    // }

    // Java是值传递，参数的数据无法修改
    // public static void triple(Integer x) {
    // x = 3 * x;
    // }

    // 修改参数值的方法
    public static void triple(IntHolder x) {
        x.value = x.value * 3;
    }

}
