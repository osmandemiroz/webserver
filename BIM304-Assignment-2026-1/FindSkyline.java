import java.util.ArrayList;

public class FindSkyline {

    /**
     * Finds the skyline of all buildings using the divide-and-conquer strategy.
     * The input array is assumed to be sorted by MergeSort.sort().
     */
    public static ArrayList<SkylinePoint> findSkyline(Building[] buildings) {
        if (buildings == null || buildings.length == 0) return new ArrayList<>();
        return findSkyline(buildings, 0, buildings.length - 1);
    }

    /**
     * Recursively finds the skyline for buildings[left..right].
     */
    private static ArrayList<SkylinePoint> findSkyline(Building[] buildings, int left, int right) {
        if (left == right) {
            return createSingleBuildingSkyline(buildings[left]);
        }
        
        int mid = left + (right - left) / 2;
        ArrayList<SkylinePoint> leftSkyline = findSkyline(buildings, left, mid);
        ArrayList<SkylinePoint> rightSkyline = findSkyline(buildings, mid + 1, right);
        
        return mergeSkylines(leftSkyline, rightSkyline);
    }

    /**
     * Creates the skyline for a single building.
     * Example: building (1, 5, 3) -> (1, 3), (5, 0)
     */
    private static ArrayList<SkylinePoint> createSingleBuildingSkyline(Building building) {
        ArrayList<SkylinePoint> skyline = new ArrayList<>();
        skyline.add(new SkylinePoint(building.getLeft(), building.getHeight()));
        skyline.add(new SkylinePoint(building.getRight(), 0));
        return skyline;
    }

    /**
     * Merges two skylines into one skyline.
     * Consecutive points with the same height must not appear in the result.
     */
    private static ArrayList<SkylinePoint> mergeSkylines(ArrayList<SkylinePoint> leftSkyline,
                                                         ArrayList<SkylinePoint> rightSkyline) {
        ArrayList<SkylinePoint> merged = new ArrayList<>();
        int h1 = 0, h2 = 0;
        int i = 0, j = 0;
        
        while (i < leftSkyline.size() && j < rightSkyline.size()) {
            SkylinePoint p1 = leftSkyline.get(i);
            SkylinePoint p2 = rightSkyline.get(j);
            
            int x;
            int maxH;
            
            if (p1.getX() < p2.getX()) {
                x = p1.getX();
                h1 = p1.getHeight();
                maxH = Math.max(h1, h2);
                addPoint(merged, x, maxH);
                i++;
            } else if (p2.getX() < p1.getX()) {
                x = p2.getX();
                h2 = p2.getHeight();
                maxH = Math.max(h1, h2);
                addPoint(merged, x, maxH);
                j++;
            } else {
                x = p1.getX();
                h1 = p1.getHeight();
                h2 = p2.getHeight();
                maxH = Math.max(h1, h2);
                addPoint(merged, x, maxH);
                i++;
                j++;
            }
        }
        
        while (i < leftSkyline.size()) {
            SkylinePoint p = leftSkyline.get(i);
            addPoint(merged, p.getX(), p.getHeight());
            i++;
        }
        
        while (j < rightSkyline.size()) {
            SkylinePoint p = rightSkyline.get(j);
            addPoint(merged, p.getX(), p.getHeight());
            j++;
        }
        
        return merged;
    }

    /**
     * Adds a point to the skyline only if it is not redundant.
     * A point is redundant if it has the same height as the previous point.
     */
    private static void addPoint(ArrayList<SkylinePoint> skyline, int x, int height) {
        if (skyline.isEmpty()) {
            skyline.add(new SkylinePoint(x, height));
            return;
        }
        
        SkylinePoint last = skyline.get(skyline.size() - 1);
        if (last.getX() == x) {
            if (height > last.getHeight()) {
                skyline.set(skyline.size() - 1, new SkylinePoint(x, height));
            }
        } else if (last.getHeight() != height) {
            skyline.add(new SkylinePoint(x, height));
        }
    }
}
