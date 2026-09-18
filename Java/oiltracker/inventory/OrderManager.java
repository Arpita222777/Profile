package inventory;

import models.Order;
import exceptions.TrackingException;
import java.io.*;
import java.util.*;

public class OrderManager {
    private final String FILE = "data/orders.txt";

    public OrderManager() {
        File file = new File(FILE);
        if (!file.exists()) {
            file.getParentFile().mkdirs();
            try { file.createNewFile(); } catch (IOException ignored) {}
        }
    }

    public void addOrder(Order o) throws TrackingException {
        try {
            FileWriter fw = new FileWriter(FILE, true);
            fw.write(o.toFileString() + "\n");
            fw.close();
        } catch (IOException e) {
            throw new TrackingException("Could not save order: " + e.getMessage());
        }
    }

    public List<Order> getAllOrders() throws TrackingException {
        List<Order> list = new ArrayList<>();
        try {
            BufferedReader br = new BufferedReader(new FileReader(FILE));
            String line;
            while ((line = br.readLine()) != null) {
                if (line.trim().isEmpty()) continue;
                String[] d = line.split(",");
                if (d.length >= 5) {
                    list.add(new Order(d[0], d[1], d[2], d[3], d[4]));
                }
            }
            br.close();
        } catch (Exception e) {
            throw new TrackingException("Could not read orders: " + e.getMessage());
        }
        return list;
    }

    public void updateOrder(Order updatedOrder) throws TrackingException {
        List<Order> list = getAllOrders();
        boolean found = false;
        try {
            FileWriter fw = new FileWriter(FILE);
            for (Order o : list) {
                if (o.getOrderId().equals(updatedOrder.getOrderId())) {
                    fw.write(updatedOrder.toFileString() + "\n");
                    found = true;
                } else {
                    fw.write(o.toFileString() + "\n");
                }
            }
            fw.close();
        } catch (Exception e) {
            throw new TrackingException("Could not update order: " + e.getMessage());
        }
        if (!found) throw new TrackingException("Order ID not found.");
    }

    public void deleteOrder(String orderId) throws TrackingException {
        List<Order> list = getAllOrders();
        boolean found = false;
        try {
            FileWriter fw = new FileWriter(FILE);
            for (Order o : list) {
                if (!o.getOrderId().equals(orderId)) {
                    fw.write(o.toFileString() + "\n");
                } else {
                    found = true;
                }
            }
            fw.close();
        } catch (Exception e) {
            throw new TrackingException("Could not delete order: " + e.getMessage());
        }
        if (!found) throw new TrackingException("Order ID not found.");
    }
}
