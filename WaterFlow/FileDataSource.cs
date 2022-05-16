using System.Collections;

namespace WaterFlow;

static class CommonString
{
    static int indexRange(this string str, char elem, ref int index)
    {
        int firstPositionElem = 0;

        while (index < str.Length) {
            if (str[index] == elem) {
                firstPositionElem = index;

                while (index < str.Length && str[index] == elem)
                    index++;
                break ;
            }
            index++;
        }
        return firstPositionElem;
    }
}

public class FileDataSource
{
    public string File { get; set; }
        
    public FileDataSource(string File)
    {
        this.File = File;
    }

    private (int Min, int Max) CreatIntLine(string line, int index, int col, int SizeLine)
    {
        (int Min, int Max) range = (index + (col * SizeLine), 0);

        for (int i = index; i < line.Length; i++) {
            if (line[i] != 'x') {
                range.Max = i - 1 + (col * SizeLine);
                break ;
            }
        }
        return range;
    }

    public DataMap ReadFile()
    {
        List<string> LineTmp = new List<string>();
        DataMap dataMap = new DataMap();
        int SizeLine = 0;

        try {
            using (StreamReader streamReader = new StreamReader(File)) {
                string line;

                while ((line = streamReader.ReadLine()) != null) {
                    if (line.Length > SizeLine)
                        SizeLine = line.Length;
                    LineTmp.Add(line);
                }
            }
        } catch (Exception e) {
            throw new Exception(e.Message);
        }

        for (int i = 0; i < LineTmp.Count; i++) {
            if (LineTmp[i].IndexOf('O') != -1)
                dataMap.Position = LineTmp[i].IndexOf('O') + (i * SizeLine);
            if (LineTmp[i].IndexOf('x') != -1) {
                Console.WriteLine($"li :: {LineTmp[i]}");
                dataMap.PaltformRangeIndex.Add(CreatIntLine(LineTmp[i], LineTmp[i].IndexOf('x'), i, SizeLine));
            }
        }
        dataMap.Width = SizeLine;
        dataMap.Height = LineTmp.Count;
        return dataMap;
    }
}