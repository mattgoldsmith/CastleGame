import javax.swing.*;
import java.awt.*;

public class GUI {
    private JFrame frame = new JFrame("Castle Game");
    private JTextArea textField = new JTextArea();

    public GUI(){
        createJFrame();
        createJTextField();
        show();
    }

    private void createJFrame(){
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }
    public JFrame getJFrame(){
        return frame;
    }

    private void createJTextField(){
        //TODO: Add Listener for enter key
        Dimension dimension = new Dimension(500,500);
        textField.setPreferredSize(dimension);
        Font font = new Font("SansSerif", Font.BOLD, 20);
        textField.setFont(font);

        getJFrame().getContentPane().add(textField);
    }
    public JTextArea getJTextField(){
        return textField;
    }

    private void show(){
        frame.pack();
        frame.setVisible(true);
    }
}
