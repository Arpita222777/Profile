package ui;

import auth.*;
import inventory.*;
import models.Order;
import exceptions.TrackingException;

import javax.swing.*;
import javax.swing.border.TitledBorder;
import java.awt.*;
import java.awt.event.*;
import java.util.List;
import java.util.UUID;

public class MainDashboard {
    private JFrame frame;
    private User currentUser;
    private InventoryManager inventoryManager;
    private OrderManager orderManager;

    private OilRecord selectedOil = null;
    private Order selectedOrder = null;

    // UI Components
    private JLabel lblSelectedOil;
    private JLabel lblSelectedOrder;
    
    public MainDashboard(User user) {
        this.currentUser = user;
        this.inventoryManager = new InventoryManager();
        this.orderManager = new OrderManager();
        
        frame = new JFrame("OilTracker - " + (user.getRole().equals("ADMIN") ? "Admin Panel" : "User Panel"));
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(900, 650);
        frame.setLayout(new BorderLayout());

        JPanel topPanel = new JPanel(new GridLayout(1, 2, 10, 10));
        topPanel.add(createSearchPanel());
        topPanel.add(createAvailablePanel());

        JPanel middlePanel = createSelectionPanel();

        JPanel bottomPanel = new JPanel(new GridLayout(1, 2, 10, 10));
        bottomPanel.add(createOrderPanel());
        bottomPanel.add(createManagePanel());

        JPanel mainContent = new JPanel();
        mainContent.setLayout(new BoxLayout(mainContent, BoxLayout.Y_AXIS));
        mainContent.add(topPanel);
        mainContent.add(middlePanel);
        mainContent.add(bottomPanel);

        frame.add(mainContent, BorderLayout.CENTER);
        frame.setVisible(true);
    }

    private JTextArea txtAvailableList;
    private DefaultListModel<OilRecord> listModelAvailable;
    private JList<OilRecord> listAvailable;

    private JPanel createSearchPanel() {
        JPanel panel = new JPanel(new GridBagLayout());
        panel.setBorder(BorderFactory.createTitledBorder(BorderFactory.createLineBorder(Color.GRAY), "Search Inventory", TitledBorder.CENTER, TitledBorder.TOP, new Font("SansSerif", Font.BOLD, 14), Color.BLUE));
        
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(5,5,5,5);
        gbc.fill = GridBagConstraints.HORIZONTAL;
        
        JTextField txtName = new JTextField(15);
        JTextField txtSupplier = new JTextField(15);
        JTextField txtDate = new JTextField(15);
        JButton btnSearch = new JButton("Search Inventory");

        gbc.gridx=0; gbc.gridy=0; panel.add(new JLabel("Oil Name/Type:"), gbc);
        gbc.gridx=1; panel.add(txtName, gbc);
        
        gbc.gridx=0; gbc.gridy=1; panel.add(new JLabel("Supplier:"), gbc);
        gbc.gridx=1; panel.add(txtSupplier, gbc);

        gbc.gridx=0; gbc.gridy=2; panel.add(new JLabel("Date (YYYY-MM-DD):"), gbc);
        gbc.gridx=1; panel.add(txtDate, gbc);

        gbc.gridx=1; gbc.gridy=3; panel.add(btnSearch, gbc);

        btnSearch.addActionListener(e -> {
            try {
                List<OilRecord> results = inventoryManager.search(txtName.getText(), txtSupplier.getText(), txtDate.getText());
                listModelAvailable.clear();
                if(results.isEmpty()) {
                    // Show empty
                } else {
                    for(OilRecord r : results) listModelAvailable.addElement(r);
                }
            } catch (Exception ex) {
                JOptionPane.showMessageDialog(frame, "Search failed: " + ex.getMessage());
            }
        });

        return panel;
    }

    private JPanel createAvailablePanel() {
        JPanel panel = new JPanel(new BorderLayout());
        panel.setBorder(BorderFactory.createTitledBorder(BorderFactory.createLineBorder(Color.GRAY), "Available Inventory", TitledBorder.CENTER, TitledBorder.TOP, new Font("SansSerif", Font.BOLD, 14), Color.BLUE));
        
        listModelAvailable = new DefaultListModel<>();
        listAvailable = new JList<>(listModelAvailable);
        listAvailable.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        
        listAvailable.addListSelectionListener(e -> {
            if (!e.getValueIsAdjusting() && listAvailable.getSelectedValue() != null) {
                selectedOil = listAvailable.getSelectedValue();
                lblSelectedOil.setText("Selected Oil: " + selectedOil.getName() + " from " + selectedOil.getSupplier() + " - $" + selectedOil.getPrice());
            }
        });

        panel.add(new JScrollPane(listAvailable), BorderLayout.CENTER);
        return panel;
    }

    private JPanel createSelectionPanel() {
        JPanel panel = new JPanel(new BorderLayout());
        panel.setBorder(BorderFactory.createTitledBorder(BorderFactory.createLineBorder(Color.GRAY), "Select Details", TitledBorder.CENTER, TitledBorder.TOP, new Font("SansSerif", Font.BOLD, 14), Color.BLUE));
        
        lblSelectedOil = new JLabel("Selected Oil: None", SwingConstants.CENTER);
        lblSelectedOrder = new JLabel("Selected Order: None", SwingConstants.CENTER);
        
        panel.add(lblSelectedOil, BorderLayout.NORTH);
        panel.add(lblSelectedOrder, BorderLayout.SOUTH);
        panel.setPreferredSize(new Dimension(800, 80));
        return panel;
    }

    private JPanel createOrderPanel() {
        JPanel panel = new JPanel(new GridBagLayout());
        panel.setBorder(BorderFactory.createTitledBorder(BorderFactory.createLineBorder(Color.GRAY), "Buyer & Order", TitledBorder.CENTER, TitledBorder.TOP, new Font("SansSerif", Font.BOLD, 14), Color.BLUE));
        
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(5,5,5,5);
        gbc.fill = GridBagConstraints.HORIZONTAL;

        JTextField txtBuyer = new JTextField(15);
        JTextField txtContact = new JTextField(15);
        JButton btnConfirm = new JButton("Confirm Order");

        gbc.gridx=0; gbc.gridy=0; panel.add(new JLabel("Buyer Name:"), gbc);
        gbc.gridx=1; panel.add(txtBuyer, gbc);
        
        gbc.gridx=0; gbc.gridy=1; panel.add(new JLabel("Contact (Email/Phone):"), gbc);
        gbc.gridx=1; panel.add(txtContact, gbc);

        gbc.gridx=1; gbc.gridy=2; panel.add(btnConfirm, gbc);

        btnConfirm.addActionListener(e -> {
            if (selectedOil == null) {
                JOptionPane.showMessageDialog(frame, "Please select an oil from Available Inventory first!");
                return;
            }
            if (txtBuyer.getText().isEmpty() || txtContact.getText().isEmpty()) {
                JOptionPane.showMessageDialog(frame, "Please enter buyer name and contact.");
                return;
            }
            
            String orderId = UUID.randomUUID().toString().substring(0, 8);
            Order newOrder = new Order(orderId, txtBuyer.getText(), txtContact.getText(), selectedOil.getName(), java.time.LocalDate.now().toString());
            
            try {
                orderManager.addOrder(newOrder);
                JOptionPane.showMessageDialog(frame, "Order Confirmed! ID: " + orderId);
            } catch (TrackingException ex) {
                JOptionPane.showMessageDialog(frame, ex.getMessage());
            }
        });

        return panel;
    }

    private DefaultListModel<Order> listModelOrders;
    private JList<Order> listOrders;

    private JPanel createManagePanel() {
        JPanel panel = new JPanel(new BorderLayout(5, 5));
        panel.setBorder(BorderFactory.createTitledBorder(BorderFactory.createLineBorder(Color.GRAY), "Manage Orders & Data", TitledBorder.CENTER, TitledBorder.TOP, new Font("SansSerif", Font.BOLD, 14), Color.BLUE));
        
        JPanel topP = new JPanel(new FlowLayout());
        JTextField txtOrderId = new JTextField(10);
        JButton btnShow = new JButton("Show My Orders");
        topP.add(new JLabel("Name/Order ID:"));
        topP.add(txtOrderId);
        topP.add(btnShow);

        listModelOrders = new DefaultListModel<>();
        listOrders = new JList<>(listModelOrders);
        listOrders.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        
        listOrders.addListSelectionListener(e -> {
            if (!e.getValueIsAdjusting() && listOrders.getSelectedValue() != null) {
                selectedOrder = listOrders.getSelectedValue();
                lblSelectedOrder.setText("Selected Order: " + selectedOrder.getOrderId() + " by " + selectedOrder.getBuyerName());
            }
        });

        JPanel botP = new JPanel(new FlowLayout());
        JButton btnUpdate = new JButton("Update Selected Order");
        JButton btnDelete = new JButton("Delete Selected Order");
        
        if (!currentUser.getRole().equals("ADMIN")) {
            // Normal users might not be allowed to delete, or maybe they can delete their own. Let's allow for the sake of CRUD demonstration.
        }

        botP.add(btnUpdate);
        botP.add(btnDelete);

        btnShow.addActionListener(e -> {
            try {
                List<Order> allOrders = orderManager.getAllOrders();
                listModelOrders.clear();
                for (Order o : allOrders) {
                    if (txtOrderId.getText().isEmpty() || o.getOrderId().contains(txtOrderId.getText()) || o.getBuyerName().contains(txtOrderId.getText())) {
                        listModelOrders.addElement(o);
                    }
                }
            } catch (TrackingException ex) {
                JOptionPane.showMessageDialog(frame, ex.getMessage());
            }
        });

        btnUpdate.addActionListener(e -> {
            if (selectedOrder == null) {
                JOptionPane.showMessageDialog(frame, "Select an order to update!");
                return;
            }
            String newContact = JOptionPane.showInputDialog(frame, "Enter new contact info:", selectedOrder.getContact());
            if (newContact != null && !newContact.isEmpty()) {
                selectedOrder.setContact(newContact);
                try {
                    orderManager.updateOrder(selectedOrder);
                    JOptionPane.showMessageDialog(frame, "Order updated successfully!");
                    btnShow.doClick(); // Refresh
                } catch (TrackingException ex) {
                    JOptionPane.showMessageDialog(frame, ex.getMessage());
                }
            }
        });

        btnDelete.addActionListener(e -> {
            if (selectedOrder == null) {
                JOptionPane.showMessageDialog(frame, "Select an order to delete!");
                return;
            }
            try {
                orderManager.deleteOrder(selectedOrder.getOrderId());
                JOptionPane.showMessageDialog(frame, "Order deleted.");
                selectedOrder = null;
                lblSelectedOrder.setText("Selected Order: None");
                btnShow.doClick(); // Refresh
            } catch (TrackingException ex) {
                JOptionPane.showMessageDialog(frame, ex.getMessage());
            }
        });

        panel.add(topP, BorderLayout.NORTH);
        panel.add(new JScrollPane(listOrders), BorderLayout.CENTER);
        panel.add(botP, BorderLayout.SOUTH);

        return panel;
    }
}
