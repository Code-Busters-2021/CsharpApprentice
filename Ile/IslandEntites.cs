namespace Ile
{
    public class IslandEntities
    {
        public IslandEntities(int x, int y, int IslandId)
        {
            this.x = x;
            this.y = y;
            this.IslandId = IslandId;
        }
        public int x { get; }
        public int y { get; }
        public int IslandId { get; set; } 
    }
}