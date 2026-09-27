package ui;

import auth.User;
import inventory.*;
import models.Order;
import exceptions.TrackingException;

import javax.swing.*;
import java.awt.*;
import java.util.List;
import java.util.UUID;

public class UserPanel extends JPanel {
    private User currentUser;
    private InventoryManager inventoryManager;
    private OrderManager orderManager;

    private DefaultListModel<OilRecord> oilListModel;
    private JList<OilRecord> oilList;

    private DefaultListModel<Order> orderListModel;
    private JList<Order> orderList;

    public UserPanel(User user) {
        this.currentUser = user;
        this.inventoryManager = new InventoryManager();
        this.orderManager = new OrderManager();
        
        setLayout(new GridLayout(2, 1, 10, 10));
        
        add(createShoppingPanel());
        add(createMyOrdersPanel());
    }

    private JPanel createShoppingPanel() {
        JPanel panel = new JPanel(new BorderLayout(10, 10));
        panel.setBorder(BorderFactory.createTitledBorder("Browse & Order Oil"));

        // Top: Search
        JPanel searchPanel = new JPanel();
        JTextField txtSearch = new JTextField(15);
        JButton btnSearch = new JButton("Search by Name");
        searchPanel.add(new JLabel("Search Name:"));
        searchPanel.add(txtSearch);
        searchPanel.add(btnSearch);

        // Center: List
        oilListModel = new DefaultListModel<>();
        oilList = new JList<>(oilListModel);
        refreshInventory("");
        panel.add(new JScrollPane(oilList), BorderLayout.CENTER);

        btnSearch.addActionListener(e -> refreshInventory(txtSearch.getText()));

        // Bottom: Order form
        JPanel orderForm = new JPanel();
        JTextField txtContact = new JTextField(15);
        JButton btnOrder = new JButton("Place Order");
        orderForm.add(new JLabel("Contact Info (Email/Phone):"));
        orderForm.add(txtContact);
        orderForm.add(btnOrder);

        btnOrder.addActionListener(e -> {
            OilRecord selected = oilList.getSelectedValue();
            if (selected == null) {
                JOptionPane.showMessageDialog(this, "Select an oil to order.");
                return;
            }
            if (txtContact.getText().isEmpty()) {
                JOptionPane.showMessageDialog(this, "Enter contact info.");
                return;
            }
            try {
                String orderId = UUID.randomUUID().toString().substring(0, 8);
                Order newOrder = new Order(orderId, currentUser.getUsername(), txtContact.getText(), selected.getName(), java.time.LocalDate.now().toString());
                orderManager.addOrder(newOrder);
                JOptionPane.showMessageDialog(this, "Order placed! ID: " + orderId);
                txtContact.setText("");
                refreshMyOrders();
            } catch (Exception ex) {
                JOptionPane.showMessageDialog(this, "Error placing order: " + ex.getMessage());
            }
        });

        JPanel topContainer = new JPanel(new BorderLayout());
        topContainer.add(searchPanel, BorderLayout.NORTH);
        panel.add(topContainer, BorderLayout.NORTH);
        panel.add(orderForm, BorderLayout.SOUTH);

        return panel;
    }

    private JPanel createMyOrdersPanel() {
        JPanel panel = new JPanel(new BorderLayout(10, 10));
        panel.setBorder(BorderFactory.createTitledBorder("My Orders"));

        orderListModel = new DefaultListModel<>();
        orderList = new JList<>(orderListModel);
        refreshMyOrders();

        panel.add(new JScrollPane(orderList), BorderLayout.CENTER);

        JPanel btnPanel = new JPanel();
        JButton btnUpdate = new JButton("Update Contact");
        JButton btnDelete = new JButton("Cancel Order");

        btnPanel.add(btnUpdate);
        btnPanel.add(btnDelete);
        panel.add(btnPanel, BorderLayout.SOUTH);

        btnUpdate.addActionListener(e -> {
            Order selected = orderList.getSelectedValue();
            if (selected != null) {
                String newContact = JOptionPane.showInputDialog(this, "Enter new contact info:", selected.getContact());
                if (newContact != null && !newContact.isEmpty()) {
                    selected.setContact(newContact);
                    try {
                        orderManager.updateOrder(selected);
                        JOptionPane.showMessageDialog(this, "Order updated!");
                        refreshMyOrders();
                    } catch (TrackingException ex) {
                        JOptionPane.showMessageDialog(this, "Error: " + ex.getMessage());
                    }
                }
            } else {
                JOptionPane.showMessageDialog(this, "Select an order to update.");
            }
        });

        btnDelete.addActionListener(e -> {
            Order selected = orderList.getSelectedValue();
            if (selected != null) {
                try {
                    orderManager.deleteOrder(selected.getOrderId());
                    JOptionPane.showMessageDialog(this, "Order cancelled.");
                    refreshMyOrders();
                } catch (TrackingException ex) {
                    JOptionPane.showMessageDialog(this, "Error: " + ex.getMessage());
                }
            } else {
                JOptionPane.showMessageDialog(this, "Select an order to cancel.");
            }
        });

        return panel;
    }

    private void refreshInventory(String keyword) {
        oilListModel.clear();
        try {
            List<OilRecord> list = inventoryManager.search(keyword, "", "");
            for (OilRecord r : list) {
                oilListModel.addElement(r);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void refreshMyOrders() {
        orderListModel.clear();
        try {
            List<Order> list = orderManager.getAllOrders();
            for (Order o : list) {
                // Only show orders for the current user
                if (o.getBuyerName().equals(currentUser.getUsername())) {
                    orderListModel.addElement(o);
                }
            }
        } catch (TrackingException e) {
            e.printStackTrace();
        }
    }
}
