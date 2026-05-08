public class MergeSort {

    /**
     * Sorts the buildings by their left coordinate in ascending order.
     * If two buildings have the same left coordinate, sort by right coordinate,
     * and then by height.
     */
    public static void sort(Building[] buildings) {
        if (buildings == null || buildings.length <= 1) return;
        Building[] temp = new Building[buildings.length];
        mergeSort(buildings, temp, 0, buildings.length - 1);
    }

    /**
     * Recursive merge sort method.
     */
    private static void mergeSort(Building[] buildings, Building[] temp, int left, int right) {
        if (left >= right) return;
        int middle = left + (right - left) / 2;
        mergeSort(buildings, temp, left, middle);
        mergeSort(buildings, temp, middle + 1, right);
        merge(buildings, temp, left, middle, right);
    }

    /**
     * Merges two sorted subarrays:
     * buildings[left..middle] and buildings[middle + 1..right].
     */
    private static void merge(Building[] buildings, Building[] temp, int left, int middle, int right) {
        for (int i = left; i <= right; i++) {
            temp[i] = buildings[i];
        }

        int i = left;
        int j = middle + 1;
        int k = left;

        while (i <= middle && j <= right) {
            if (comesBeforeOrEqual(temp[i], temp[j])) {
                buildings[k] = temp[i];
                i++;
            } else {
                buildings[k] = temp[j];
                j++;
            }
            k++;
        }

        while (i <= middle) {
            buildings[k] = temp[i];
            k++;
            i++;
        }
    }

    /**
     * Returns true if b1 must come before b2 in the sorted order.
     */
    private static boolean comesBeforeOrEqual(Building b1, Building b2) {
        if (b1.getLeft() != b2.getLeft()) {
            return b1.getLeft() < b2.getLeft();
        }
        if (b1.getRight() != b2.getRight()) {
            return b1.getRight() < b2.getRight();
        }
        return b1.getHeight() <= b2.getHeight();
    }
}
