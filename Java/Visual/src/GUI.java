import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

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
//        label.setPreferredSize(dimension);
        JScrollPane scrollPane = new JScrollPane(label);
        scrollPane.setPreferredSize(dimension);
        Font font = new Font("SansSerif", Font.BOLD, 20);
        label.setFont(font);
        label.setBorder(BorderFactory.createMatteBorder(0, 0, 1, 0, Color.BLACK));
        label.setEditable(false);
        label.setLineWrap(true);
        label.setWrapStyleWord(true);
        frame.getContentPane().add(scrollPane, BorderLayout.NORTH);
    }
    public JTextArea getLabel(){
        return label;
    }

    private void show(){
        frame.pack();
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
        textField.grabFocus();
        textField.requestFocus();
    }

    public void setText(String input){
        String text = label.getText();
        label.setText(text + input + "\n");
    }

    public JFrame getFrame(){
        return frame;
    }

}
