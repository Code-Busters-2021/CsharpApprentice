using System;
using System.IO;

namespace Ile
{
    public class ParsingMap
    {
        public string File { get; set; }
        
        public ParsingMap(string File)
        {
            this.File = File;
        }

        private int[] CreatIntLine(string[] line)
        {
            List<int> ints = new List<int>();

            foreach (string elem in line) {
                if (int.TryParse(elem, out int value))
                    ints.Add(value);
                else
                    throw new Exception($"Invalide input {elem}: Map must Contain only integers value");
            }
            return ints.ToArray();
        } 

        public int[][] ReadFile()
        {
            List<int[]> map = new List<int[]>();

            try {
                using (StreamReader streamReader = new StreamReader(File)) {
                    string line;
                    while ((line = streamReader.ReadLine()) != null) {
                        map.Add(CreatIntLine(line.Split(' ')));
                    }
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
            return map.ToArray();
        }
    }
}