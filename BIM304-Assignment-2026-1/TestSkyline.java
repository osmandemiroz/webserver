import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class TestSkyline {
    public static void main(String[] args) throws IOException {
        if (args.length != 1) {
            System.out.println("Usage: java TestSkyline <input-file>");
            return;
        }

        Building[] buildings = readBuildings(args[0]);
        MergeSort.sort(buildings);
        ArrayList<SkylinePoint> skyline = FindSkyline.findSkyline(buildings);
        printSkyline(skyline);
    }

    private static Building[] readBuildings(String fileName) throws IOException {
        BufferedReader br = new BufferedReader(new FileReader(fileName));
        int n = Integer.parseInt(br.readLine().trim());
        Building[] buildings = new Building[n];

        for (int i = 0; i < n; i++) {
            String line = br.readLine();
            while (line != null && line.trim().isEmpty()) {
                line = br.readLine();
            }
            StringTokenizer st = new StringTokenizer(line);
            int left = Integer.parseInt(st.nextToken());
            int right = Integer.parseInt(st.nextToken());
            int height = Integer.parseInt(st.nextToken());
            buildings[i] = new Building(left, right, height);
        }

        br.close();
        return buildings;
    }

    private static void printSkyline(ArrayList<SkylinePoint> skyline) {
        for (int i = 0; i < skyline.size(); i++) {
            if (i > 0) {
                System.out.print(" ");
            }
            System.out.print(skyline.get(i));
        }
        System.out.println();
    }
}
