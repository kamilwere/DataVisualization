using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisParameters : MonoBehaviour
{
    public Color color;
    [SerializeField]
    private float length = 1.0f;
    public float width = 0.1f;
    public float arrowLength = 0.25f;
    
    private Material mat;
    private ConeGenerator cone;

    public float Length { get => length; set
        {
            length = value;
            this.transform.localScale = new Vector3(width, Length, width);
            if (cone != null)
            {
                cone.height = arrowLength / value;
                cone.UpdateMesh();
            }
        }
    }

    public float ArrowLength
    {
        get => length; set
        {
            arrowLength = value;
            if (cone != null)
            {
                cone.height = arrowLength / length;
                cone.UpdateMesh();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i)!=null)
            {
                var ch=this.transform.GetChild(i);
                if (ch.name == "Cone")
                    cone = ch.transform.GetComponent<ConeGenerator>();
            }
        }
        if (mat.color != color)
            mat.color = color;

        if (cone != null)
            cone.color = color;

        this.transform.localScale = new Vector3(width, Length, width);
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
