namespace WaterFlow;

class ResolveWaterFlow
{
    private DataMap map { get; }
    public ResolveWaterFlow(DataMap map)
    {
        this.map = map;
    }

    public BinaryTree createBinaryTree(BinaryTree root, int value, int index)
    {
        while (index < map.PaltformRangeIndex.Count) {
            Console.WriteLine($"tab = V::{value % map.Width} {map.PaltformRangeIndex[index].Min % map.Width} | {map.PaltformRangeIndex[index].Max % map.Width}");
            if (value >= map.PaltformRangeIndex[index].Min % map.Width && value <= map.PaltformRangeIndex[index].Max % map.Width) {
                root.value = value;
                root.left = createBinaryTree(root.left, map.PaltformRangeIndex[index].Min, index + 1);
                root.reight = createBinaryTree(root.reight, map.PaltformRangeIndex[index].Max, index + 1);
                return root;
            } else {
                index++;
            }
        }
        return root;
    }

    public BinaryTree SortHunderScore(BinaryTree root, int value, int index)
    {
        if (value >= map.PaltformRangeIndex[index].Min && value <= map.PaltformRangeIndex[index].Max) {
            root.left = createBinaryTree(root.left, map.PaltformRangeIndex[index].Min, index + 1);
            root.reight = createBinaryTree(root.reight, map.PaltformRangeIndex[index].Max, index + 1);
        }
        return root;
    }

}