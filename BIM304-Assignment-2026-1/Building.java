public class Building {
    private int left;
    private int right;
    private int height;

    public Building(int left, int right, int height) {
        this.left = left;
        this.right = right;
        this.height = height;
    }

    public int getLeft() {
        return left;
    }

    public int getRight() {
        return right;
    }

    public int getHeight() {
        return height;
    }

    @Override
    public String toString() {
        return "Building: Left: " + left + ", Right: " + right + ", Height: " + height;
    }
}
