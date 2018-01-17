import java.awt.event.ActionListener;
import javax.swing.*;

public class App {


    public static void main(String[] args) {

        ActionListener listener = new TimePrinter();
        Timer time = new Timer(1000, listener);
        time.start();

        JOptionPane.showMessageDialog(null, "Quit program?");

        System.exit(0);
    }

}


