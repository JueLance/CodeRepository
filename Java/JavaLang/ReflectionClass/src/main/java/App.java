import java.lang.reflect.Field;
import java.lang.reflect.Modifier;

public class App {
    public static void main(String[] args) {
        Class<UserInfo> fyBasicInfoDtoClass = UserInfo.class;
        Field[] fields = fyBasicInfoDtoClass.getDeclaredFields();
        for (Field field : fields) {
//            if (field.getModifiers() == Modifier.PRIVATE)
                System.out.println(field.getType().getSimpleName() + " " + field.getName());
        }

    }
}
