package ui;

import javax.swing.*;
import auth.*;

public class LoginUI {
    public LoginUI() {
        JFrame frame = new JFrame("Oil Tracker Login");

        JTextField user = new JTextField();
        JPasswordField pass = new JPasswordField();

        JButton login = new JButton("Login");
        JButton register = new JButton("Register");

        frame.setLayout(new java.awt.GridLayout(4,2));

        frame.add(new JLabel("Username"));
        frame.add(user);
        frame.add(new JLabel("Password"));
        frame.add(pass);
        frame.add(login);
        frame.add(register);

        UserManager manager = new UserManager();

        login.addActionListener(e -> {
            User u = manager.login(user.getText(), new String(pass.getPassword()));
            if (u != null) {
                JOptionPane.showMessageDialog(frame, "Welcome " + u.getRole());
                new DashboardUI(u);
                frame.dispose();
            } else {
                JOptionPane.showMessageDialog(frame, "Invalid");
            }
        });

        register.addActionListener(e -> {
            manager.register(user.getText(), new String(pass.getPassword()), "USER");
            JOptionPane.showMessageDialog(frame, "Registered");
        });

        frame.setSize(300,200);
        frame.setVisible(true);
    }
}