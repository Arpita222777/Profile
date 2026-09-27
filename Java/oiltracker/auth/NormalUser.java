package auth;

public class NormalUser extends User {
    public NormalUser(String u, String p) {
        super(u, p);
    }

    @Override
    public String getRole() {
        return "USER";
    }
}