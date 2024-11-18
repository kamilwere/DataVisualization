using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum AxisWidths
{
    TINY,
    SMALL,
    NORMAL,
    THICK,
    EXTRA_THICK
}

public class OriginParameters : MonoBehaviour
{
    // Start is called before the first frame update

    public AxisWidths AxisWidth = AxisWidths.NORMAL;
    private GameObject XAxis, YAxis, ZAxis;
    public Vector3 AxisLengths = Vector3.one;
    public Vector3 ArrowLengths = Vector3.one*0.25f;

    private void SetWidth(GameObject g, AxisWidths width)
    {
        if (width == AxisWidths.TINY) 
            g.GetComponent<AxisParameters>().width = 0.02f;

        if (width == AxisWidths.SMALL)
            g.GetComponent<AxisParameters>().width = 0.05f;

        if (width == AxisWidths.NORMAL)
            g.GetComponent<AxisParameters>().width = 0.1f;

        if (width == AxisWidths.THICK)
            g.GetComponent<AxisParameters>().width = 0.2f;

        if (width == AxisWidths.EXTRA_THICK)
            g.GetComponent<AxisParameters>().width = 0.5f;
    }

    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            var child = this.transform.GetChild(i);
            if (child.name == "XAxis")
                XAxis = child.gameObject;
            if (child.name == "YAxis")
                YAxis = child.gameObject;
            if (child.name == "ZAxis")
                ZAxis = child.gameObject;
        }
        SetWidth(XAxis, AxisWidth);
        SetWidth(YAxis, AxisWidth);
        SetWidth(ZAxis, AxisWidth);
        XAxis.GetComponent<AxisParameters>().Length = AxisLengths.x;
        YAxis.GetComponent<AxisParameters>().Length = AxisLengths.y;
        ZAxis.GetComponent<AxisParameters>().Length = AxisLengths.z;
        XAxis.GetComponent<AxisParameters>().ArrowLength = ArrowLengths.x;
        YAxis.GetComponent<AxisParameters>().ArrowLength = ArrowLengths.y;
        ZAxis.GetComponent<AxisParameters>().ArrowLength = ArrowLengths.z;
    }

    // Update is called once per frame
    void Update()
    {
        XAxis.GetComponent<AxisParameters>().Length = AxisLengths.x;
        YAxis.GetComponent<AxisParameters>().Length = AxisLengths.y;
        ZAxis.GetComponent<AxisParameters>().Length = AxisLengths.z;
        XAxis.GetComponent<AxisParameters>().ArrowLength = ArrowLengths.x;
        YAxis.GetComponent<AxisParameters>().ArrowLength = ArrowLengths.y;
        ZAxis.GetComponent<AxisParameters>().ArrowLength = ArrowLengths.z;
    }
}
