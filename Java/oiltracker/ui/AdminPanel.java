package ui;

import inventory.*;
import models.Order;
import exceptions.TrackingException;

import javax.swing.*;
import java.awt.*;
import java.util.List;

public class AdminPanel extends JPanel {
    private InventoryManager inventoryManager;
    private OrderManager orderManager;

    private DefaultListModel<OilRecord> oilListModel;
    private JList<OilRecord> oilList;

    private DefaultListModel<Order> orderListModel;
    private JList<Order> orderList;

    public AdminPanel() {
        inventoryManager = new InventoryManager();
        orderManager = new OrderManager();
        setLayout(new GridLayout(2, 1, 10, 10));

        add(createInventoryManagementPanel());
        add(createOrderManagementPanel());
    }

    private JPanel createInventoryManagementPanel() {
        JPanel panel = new JPanel(new BorderLayout(10, 10));
        panel.setBorder(BorderFactory.createTitledBorder("Manage Inventory (Admin)"));

        // Left side: Add new Oil Form
        JPanel formPanel = new JPanel(new GridLayout(6, 2, 5, 5));
        JTextField txtName = new JTextField();
        JTextField txtQuantity = new JTextField();
        JTextField txtPrice = new JTextField();
        JTextField txtSupplier = new JTextField();
        JTextField txtDate = new JTextField();

        formPanel.add(new JLabel("Oil Name:")); formPanel.add(txtName);
        formPanel.add(new JLabel("Quantity:")); formPanel.add(txtQuantity);
        formPanel.add(new JLabel("Price:")); formPanel.add(txtPrice);
        formPanel.add(new JLabel("Supplier:")); formPanel.add(txtSupplier);
        formPanel.add(new JLabel("Date (YYYY-MM-DD):")); formPanel.add(txtDate);

        JButton btnAdd = new JButton("Add Inventory");
        JButton btnDelete = new JButton("Delete Selected");
        
        JPanel btnPanel = new JPanel();
        btnPanel.add(btnAdd);
        btnPanel.add(btnDelete);
        
        JPanel leftPanel = new JPanel(new BorderLayout());
        leftPanel.add(formPanel, BorderLayout.CENTER);
        leftPanel.add(btnPanel, BorderLayout.SOUTH);

        // Right side: List of current inventory
        oilListModel = new DefaultListModel<>();
        oilList = new JList<>(oilListModel);
        refreshInventory();

        panel.add(leftPanel, BorderLayout.WEST);
        panel.add(new JScrollPane(oilList), BorderLayout.CENTER);

        btnAdd.addActionListener(e -> {
            try {
                OilRecord record = new OilRecord(
                    txtName.getText(),
                    Integer.parseInt(txtQuantity.getText()),
                    Double.parseDouble(txtPrice.getText()),
                    txtSupplier.getText(),
                    txtDate.getText()
                );
                inventoryManager.addRecord(record);
                JOptionPane.showMessageDialog(this, "Added successfully!");
                refreshInventory();
                
                // Clear fields
                txtName.setText(""); txtQuantity.setText(""); txtPrice.setText("");
                txtSupplier.setText(""); txtDate.setText("");
            } catch (Exception ex) {
                JOptionPane.showMessageDialog(this, "Error adding: " + ex.getMessage());
            }
        });

        btnDelete.addActionListener(e -> {
            OilRecord selected = oilList.getSelectedValue();
            if (selected != null) {
                try {
                    inventoryManager.delete(selected.getName());
                    JOptionPane.showMessageDialog(this, "Deleted successfully!");
                    refreshInventory();
                } catch (Exception ex) {
                    JOptionPane.showMessageDialog(this, "Error deleting: " + ex.getMessage());
                }
            } else {
                JOptionPane.showMessageDialog(this, "Please select an item to delete.");
            }
        });

        return panel;
    }

    private JPanel createOrderManagementPanel() {
        JPanel panel = new JPanel(new BorderLayout(10, 10));
        panel.setBorder(BorderFactory.createTitledBorder("View All User Orders (Admin)"));

        orderListModel = new DefaultListModel<>();
        orderList = new JList<>(orderListModel);
        refreshOrders();

        panel.add(new JScrollPane(orderList), BorderLayout.CENTER);

        JButton btnRefresh = new JButton("Refresh Orders");
        btnRefresh.addActionListener(e -> refreshOrders());
        panel.add(btnRefresh, BorderLayout.SOUTH);

        return panel;
    }

    private void refreshInventory() {
        oilListModel.clear();
        try {
            List<OilRecord> list = inventoryManager.getAll();
            for (OilRecord r : list) {
                oilListModel.addElement(r);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void refreshOrders() {
        orderListModel.clear();
        try {
            List<Order> list = orderManager.getAllOrders();
            for (Order o : list) {
                orderListModel.addElement(o);
            }
        } catch (TrackingException e) {
            e.printStackTrace();
        }
    }
}
