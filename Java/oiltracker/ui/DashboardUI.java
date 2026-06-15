package ui;

import auth.User;

import javax.swing.*;
import java.awt.*;

public class DashboardUI {
    private JFrame frame;

    public DashboardUI(User user) {
        frame = new JFrame("OilTracker - Dashboard");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(900, 650);
        frame.setLayout(new BorderLayout());

        // Header
        JPanel headerPanel = new JPanel(new BorderLayout());
        headerPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));
        headerPanel.setBackground(new Color(230, 230, 250)); // Light lavender background

        JLabel welcomeLabel = new JLabel("Welcome, " + user.getUsername() + " (" + user.getRole() + ")", SwingConstants.CENTER);
        welcomeLabel.setFont(new Font("Arial", Font.BOLD, 22));
        welcomeLabel.setForeground(new Color(0, 51, 102));
        headerPanel.add(welcomeLabel, BorderLayout.CENTER);
        
        JButton logoutBtn = new JButton("Logout");
        logoutBtn.setFont(new Font("Arial", Font.BOLD, 14));
        logoutBtn.setBackground(new Color(255, 69, 0));
        logoutBtn.setForeground(Color.WHITE);
        logoutBtn.setFocusPainted(false);
        logoutBtn.addActionListener(e -> {
            new LoginUI();
            frame.dispose();
        });
        headerPanel.add(logoutBtn, BorderLayout.EAST);

        frame.add(headerPanel, BorderLayout.NORTH);

        // Main Content Area based on User Role
        if (user.getRole().equals("ADMIN")) {
            frame.add(new AdminPanel(), BorderLayout.CENTER);
        } else {
            frame.add(new UserPanel(user), BorderLayout.CENTER);
        }

        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }
}
