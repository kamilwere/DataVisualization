using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;
public class ReadCSV : MonoBehaviour
{
    public string filename;
    public List<List<string>> Data= new List<List<string>>();
    // Start is called before the first frame update
    void Start()
    {
        using (var reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                Data.Add(new List<string>(values));
            }
        }

        foreach (var line in Data)
        {
            string s="";
            foreach (var cell in line)
            {

                s += " | "+cell;
            }
            Debug.Log(s);
        }

        var defSeries=this.transform.GetComponentInChildren<DefineSeries>();
        List<int> cols= new List<int>();
        cols.Add(9);
        cols.Add(10);
        cols.Add(11);
        cols.Add(12);
        var groups = new List<Color>();
        groups.Add(Color.gray);
        groups.Add(Color.blue);
        groups.Add(Color.red);
        groups.Add(Color.green);
        var colors=new List<List<Color>>();
        var series=PrepareSeries(2, cols, groups, ref colors);
        defSeries.CreateSeries(series, colors);
    }

    //private int GetGroupIndex(ref List<string> groups, int row, int groupBy)
    //{
    //    if (row < Data.Count) {
    //        if (groupBy < Data[row].Count)
    //        {
    //            var groupingElement = Data[row][groupBy];
    //            if (groups.Contains(groupingElement))
    //                return groups.IndexOf(groupingElement);
    //            else
    //            {
    //                groups.Add(groupingElement);
    //                return groups.IndexOf(groupingElement);
    //            }
    //        }

    //    }
    //    return -1;
    //}

    public List<List<float>> PrepareSeries(int groupBy, List<int> columnsForVisualisation, List<Color> groups, ref List<List<Color>> colors)
    {
        List<List<float>> series=new List<List<float>>();
        for (int i = 0; i < columnsForVisualisation.Count; i++)
        {
            series.Add(new List<float>());
            colors.Add(new List<Color>());
        }

        
        for(int rowIndex=1; rowIndex<Data.Count; rowIndex++)
        {
            int currentGroup = int.Parse(Data[rowIndex][groupBy])-1;
            for (int j=0; j<columnsForVisualisation.Count; j++)
            {
                int colindex=columnsForVisualisation[j];
                float item = float.Parse(Data[rowIndex][colindex]);
                series[j].Add(item);
                colors[j].Add(groups[currentGroup]);
                Debug.Log(currentGroup);
            }
        }
        return series;
    }
}
