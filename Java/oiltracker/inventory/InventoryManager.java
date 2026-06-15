package inventory;

import java.io.*;
import java.util.*;

public class InventoryManager {
    private final String FILE = "data/inventory.txt";

    public InventoryManager() {
        File file = new File(FILE);
        if (!file.exists()) {
            file.getParentFile().mkdirs();
            try { file.createNewFile(); } catch (IOException ignored) {}
        }
    }

    public void addRecord(OilRecord r) throws IOException {
        FileWriter fw = new FileWriter(FILE, true);
        fw.write(r.toFileString() + "\n");
        fw.close();
    }

    public List<OilRecord> getAll() throws Exception {
        List<OilRecord> list = new ArrayList<>();
        BufferedReader br = new BufferedReader(new FileReader(FILE));
        String line;
        while ((line = br.readLine()) != null) {
            if (line.trim().isEmpty()) continue;
            String[] d = line.split(",");
            if (d.length >= 5) {
                list.add(new OilRecord(d[0], Integer.parseInt(d[1]), Double.parseDouble(d[2]), d[3], d[4]));
            } else if (d.length >= 3) {
                // Backward compatibility
                list.add(new OilRecord(d[0], Integer.parseInt(d[1]), Double.parseDouble(d[2]), "Unknown", "2026-01-01"));
            }
        }
        br.close();
        return list;
    }

    public void delete(String name) throws Exception {
        List<OilRecord> list = getAll();
        FileWriter fw = new FileWriter(FILE);

        for (OilRecord r : list) {
            if (!r.getName().equals(name)) {
                fw.write(r.toFileString() + "\n");
            }
        }
        fw.close();
    }

    public List<OilRecord> search(String name, String supplier, String date) throws Exception {
        List<OilRecord> results = new ArrayList<>();
        for (OilRecord r : getAll()) {
            boolean match = true;
            if (name != null && !name.isEmpty() && !r.getName().toLowerCase().contains(name.toLowerCase())) match = false;
            if (supplier != null && !supplier.isEmpty() && !r.getSupplier().toLowerCase().contains(supplier.toLowerCase())) match = false;
            if (date != null && !date.isEmpty() && !r.getDate().equals(date)) match = false;

            if (match) {
                results.add(r);
            }
        }
        return results;
    }
}