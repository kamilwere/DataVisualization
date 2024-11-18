using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
public enum BarTypes
{
    Cube,
    Cylinder,
    Capsule,
    Cone
}
public class SerieService : MonoBehaviour
{
    public int SerieZSlot = 0;
    public UnityEngine.Vector2 SlotSize = new UnityEngine.Vector2(0.2f, 0.2f);
    public float AnimationSpeed = 0.1f;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var children = GetComponentsInChildren<GraphBar>(true);
        foreach (var child in children) 
        {
            if (child.VerticalScale < 1.0f)
            {
                child.VerticalScale += Time.deltaTime * AnimationSpeed;
                child.transform.Rotate(new UnityEngine.Vector3(0,1,0), Time.deltaTime * AnimationSpeed * 90);
                //Debug.Log(Time.deltaTime);
                //Debug.Log(Time.deltaTime * AnimationSpeed * 2 * Mathf.PI);
            }
        }
    }
    
    public GraphBar CreateBar(float value, int slot, BarTypes barType, Color c, bool active=true, bool zeroed=false)
    {
        GameObject newBar=null;
        if (barType==BarTypes.Cube)
            newBar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        if (barType == BarTypes.Capsule)
            newBar = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        if (barType == BarTypes.Cylinder)
            newBar = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        if (newBar == null)
        {
            newBar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
        var bar=newBar.AddComponent<GraphBar>();
        bar.BarColor = c;
        bar.BarSize = SlotSize;
        bar.BarPosition = new UnityEngine.Vector2(SlotSize.x*slot+0.5f*SlotSize.x, SlotSize.y* SerieZSlot+0.5f* SlotSize.y);
        bar.Value = value;
        newBar.SetActive(active);
        if (zeroed)
            bar.VerticalScale = 0;
        newBar.transform.SetParent(transform,false);
        return bar;
    }
}
