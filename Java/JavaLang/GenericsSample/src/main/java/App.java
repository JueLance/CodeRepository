import java.util.ArrayList;
import java.util.List;

public class App {
    public static void main(String[] args) {
        Boxing boxing = new Boxing();
        boxing.run();

        testGenericsMethod();

        System.out.println();
    }

    private static void testGenericsMethod() {
        List<String> listString = new ArrayList<>();
        listString.add("JueLance");
        listString.add("Rocky");

        GetAges(listString, "20");

        List<Integer> listInt= new ArrayList<>();
        listInt.add(20);
        listInt.add(50);

        GetAges(listInt, "20");
    }

    private static <T, E> void GetAges(List<T> list, E age) {

        if (list.size() > 0) {
            for (T t : list) {
                System.out.println(t + ", " + age);
            }

        }
    }
}
