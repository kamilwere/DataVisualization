using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphBar : MonoBehaviour
{
    public Color BarColor = Color.blue;
    public float Value = 2.0f;
    public Vector2 BarSize = new Vector2(0.2f, 0.2f);
    public Vector3 Origin = new Vector3 (0, 0, 0);
    public Vector2 BarPosition =new Vector2 (0, 0);
    public float VerticalScale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(BarSize.y, Value * VerticalScale, BarSize.x);
        this.transform.position = Origin + new Vector3(BarPosition.x, Value * VerticalScale / 2, BarPosition.y);
        if (this.GetComponent<Renderer>())
            this.GetComponent<Renderer>().material.color = BarColor;
        else
            Debug.Log("Bar has no Renderer component");
    }
}
