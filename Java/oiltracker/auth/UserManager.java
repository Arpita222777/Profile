package auth;

import java.io.*;
import java.util.*;

public class UserManager {
    private final String FILE = "data/users.txt";

    public boolean register(String username, String password, String role) {
        try (FileWriter fw = new FileWriter(FILE, true)) {
            fw.write(username + "," + password + "," + role + "\n");
            return true;
        } catch (IOException e) {
            e.printStackTrace();
        }
        return false;
    }

    public User login(String username, String password) {
        try (BufferedReader br = new BufferedReader(new FileReader(FILE))) {
            String line;
            while ((line = br.readLine()) != null) {
                String[] data = line.split(",");
                if (data[0].equals(username) && data[1].equals(password)) {
                    if (data[2].equals("ADMIN"))
                        return new Admin(username, password);
                    else
                        return new NormalUser(username, password);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }
}