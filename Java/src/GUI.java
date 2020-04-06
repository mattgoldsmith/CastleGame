import javax.swing.*;
import javax.swing.border.Border;
import java.awt.*;

public class GUI {
    private JFrame frame = new JFrame("Castle Game");
    private JTextField textField = new JTextField();
    private JTextArea label = new JTextArea();

    public GUI(){
        createJFrame();
        createLabel();
        createJTextField();
        show();
    }

    private void createJFrame(){
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

    private void createJTextField(){
        //TODO: Add Listener for enter key
        Dimension dimension = new Dimension(1000,35);
        textField.setPreferredSize(dimension);
        Font font = new Font("SansSerif", Font.BOLD, 20);
        textField.setFont(font);
        textField.setBorder(BorderFactory.createEmptyBorder(0, 5, 0, 5));

       frame.getContentPane().add(textField, BorderLayout.SOUTH);
    }
    public JTextField getJTextField(){
        return textField;
    }

    private void createLabel(){
        Dimension dimension = new Dimension(1000,500);
        label.setPreferredSize(dimension);
        Font font = new Font("SansSerif", Font.BOLD, 20);
        label.setFont(font);
        label.setBorder(BorderFactory.createMatteBorder(0, 0, 1, 0, Color.BLACK));
        label.setEditable(false);
        label.setLineWrap(true);
        frame.getContentPane().add(label, BorderLayout.NORTH);
    }
    public JTextArea getLabel(){
        return label;
    }

    private void show(){
        frame.pack();
        frame.setVisible(true);
    }

    public void setText(String input){
        String text = label.getText();
        label.setText(text + input + "\n");
    }
}
