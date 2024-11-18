using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefineSeries : MonoBehaviour
{
    public void CreateSeries(List<List<float>> dataSeries, List<List<Color>> colors)
    {
        int i=0;
        foreach (var serie in dataSeries)
        {
            string name = "serie" + i;
            GameObject serieObject = new GameObject(name);
            serieObject.transform.parent = transform;
            var serieService = serieObject.AddComponent<SerieService>();
            serieService.SerieZSlot = i;
            serieService.SlotSize = new Vector2(0.2f, 0.2f);
            serieService.AnimationSpeed = 0.5f;
            int slot = 0;
            foreach (var item in serie)
            {
                var bar=serieService.CreateBar(dataSeries[i][slot], slot, BarTypes.Cube, colors[i][slot], true, true);
                bar.BarSize = serieService.SlotSize * 0.8f;
                slot++;
            }
            i++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //GameObject serie1 = new GameObject("serie1");
        //serie1.transform.parent = transform;
        //var serie1service=serie1.AddComponent<SerieService>();
        //serie1service.SerieZSlot = 0;
        //serie1service.SlotSize = new Vector2(0.2f, 0.2f);
        //serie1service.AnimationSpeed = 0.25f;
        //serie1service.CreateBar(1.5f, 0, BarTypes.Cube, Color.gray, true, true);
        //serie1service.CreateBar(1.0f, 1, BarTypes.Cube, Color.blue, true, true);
        //serie1service.CreateBar(0.7f, 2, BarTypes.Cube, Color.red, true, true);
        //serie1service.CreateBar(0.95f, 3, BarTypes.Cube, Color.green, true, true);

        //GameObject serie2 = new GameObject("serie1");
        //serie2.transform.parent = transform;
        //var serie2service = serie1.AddComponent<SerieService>();
        //serie2service.SerieZSlot = 2;
        //serie2service.SlotSize = new Vector2(0.2f, 0.2f);
        //serie2service.AnimationSpeed = 1.0f;
        //serie2service.CreateBar(1.7f, 0, BarTypes.Cube, Color.gray, true, true);
        //serie2service.CreateBar(0.9f, 1, BarTypes.Cube, Color.blue, true, true);
        //serie2service.CreateBar(0.76f, 2, BarTypes.Cube, Color.red, true, true);
        //serie2service.CreateBar(1.28f, 3, BarTypes.Cube, Color.green, true, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
