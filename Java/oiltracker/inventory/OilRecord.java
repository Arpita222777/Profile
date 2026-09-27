package inventory;

public class OilRecord {
    private String name;
    private int quantity;
    private double price;
    private String supplier;
    private String date;

    public OilRecord(String name, int quantity, double price, String supplier, String date) {
        this.name = name;
        this.quantity = quantity;
        this.price = price;
        this.supplier = supplier;
        this.date = date;
    }

    public String getName() { return name; }
    public int getQuantity() { return quantity; }
    public double getPrice() { return price; }
    public String getSupplier() { return supplier; }
    public String getDate() { return date; }

    public void setQuantity(int quantity) { this.quantity = quantity; }
    public void setPrice(double price) { this.price = price; }
    public void setSupplier(String supplier) { this.supplier = supplier; }
    public void setDate(String date) { this.date = date; }

    public String toFileString() {
        return name + "," + quantity + "," + price + "," + supplier + "," + date;
    }

    @Override
    public String toString() {
        return name + " - " + supplier + " - $" + price + " (Qty: " + quantity + ", Date: " + date + ")";
    }
}