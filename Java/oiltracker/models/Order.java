package models;

public class Order {
    private String orderId;
    private String buyerName;
    private String contact;
    private String oilName;
    private String date;

    public Order(String orderId, String buyerName, String contact, String oilName, String date) {
        this.orderId = orderId;
        this.buyerName = buyerName;
        this.contact = contact;
        this.oilName = oilName;
        this.date = date;
    }

    public String getOrderId() { return orderId; }
    public String getBuyerName() { return buyerName; }
    public String getContact() { return contact; }
    public String getOilName() { return oilName; }
    public String getDate() { return date; }

    public void setBuyerName(String buyerName) { this.buyerName = buyerName; }
    public void setContact(String contact) { this.contact = contact; }
    public void setOilName(String oilName) { this.oilName = oilName; }
    public void setDate(String date) { this.date = date; }

    public String toFileString() {
        return orderId + "," + buyerName + "," + contact + "," + oilName + "," + date;
    }

    @Override
    public String toString() {
        return "Order ID: " + orderId + ", Buyer: " + buyerName + ", Oil: " + oilName + ", Date: " + date;
    }
}
