namespace Ile
{
    public class Map
    {
        // private int[][] map = new int[][] {
        //     new int[] { 0, 0, 0, 0, 0, 1, 0 },
        //     new int[] { 0, 0, 1, 1, 1, 1, 0 },
        //     new int[] { 0, 0, 0, 0, 0, 0, 0 },
        //     new int[] { 0, 1, 1, 1, 0, 1, 1 },
        //     new int[] { 0, 0, 1, 0, 0, 0, 1 } 
        // };

        private int[][] map { get; set; }

        public Map(int[][] map)
        {
            this.map = map;
        }

        public bool AreLandLeft(int i, int j)
        {
            if (j - 1 >= 0)
                return map[i][j -1] == 1;
            return false;
        }
        
        public bool AreLandTop(int i, int j)
        {
            if (i - 1 >= 0) {
                return map[i - 1][j] == 1;
            }
            return false;
        }

        public bool IsExistingIsland(int i, int j)
        {
            // Console.WriteLine($"i = {i} j = {j} left = {AreLandLeft(i, j)} top = {AreLandTop(i, j)}");
            return AreLandLeft(i, j) || AreLandTop(i, j);
        }

        public int CountIsland()
        {
            int CountIsland = 0;

            for (int i = 0; i < map.Length; i++) { 
                for (int j = 0; j < map[i].Length; j++) {
                    if (map[i][j] == 0)
                        continue ;
                    if (AreLandTop(i, j))
                        CountIsland--;
                    if (AreLandLeft(i, j))
                        CountIsland++;
                }
                Console.WriteLine($"count = {CountIsland}");
            }
            return CountIsland;
        }
    }
}