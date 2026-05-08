public class SkylinePoint {
    private int x;
    private int height;

    public SkylinePoint(int x, int height) {
        this.x = x;
        this.height = height;
    }

    public int getX() {
        return x;
    }

    public int getHeight() {
        return height;
    }

    @Override
    public String toString() {
        return "(" + x + ", " + height + ")";
    }
}
