using Unity.VisualScripting;
using UnityEngine;

public class ConeGenerator : MonoBehaviour
{
    public int segments = 20;
    public float radius = 0.5f;
    //public float ArrowHeight = 0.25f;
    public float height=1.0f;
    public Vector3 position = Vector3.zero;
    public Color color = Color.black;
    private MeshRenderer meshRenderer;

    //private void SetHeight()
    //{
    //    var Parent=transform.parent;
    //    if (Parent != null)
    //        height = ArrowHeight / Parent.GetComponent<AxisParameters>().Length;
    //    else
    //        height = 0.25f;
    //}
    public MeshFilter mf;
    private Mesh mesh;
    void Start()
    {
        //SetHeight();
        mf = this.gameObject.AddComponent<MeshFilter>();
        mesh = new Mesh();
        mf.mesh = mesh;

        Vector3[] vertices = new Vector3[2 * segments + 2];
        int[] triangles = new int[(2 * segments + 2) * 3];
        SetVerticesAndTriangles(ref vertices, ref triangles);

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        meshRenderer = this.gameObject.AddComponent<MeshRenderer>();

    }

    public void UpdateMesh()
    {
        var v = mesh.vertices;
        var t=mesh.triangles;
        SetVerticesAndTriangles(ref v, ref t);
        mesh.vertices = v;
        mesh.triangles = t;
        mesh.RecalculateNormals();
    }
    private void SetVerticesAndTriangles(ref Vector3[] vertices, ref int[] triangles)
    {
        vertices[0] = position; // Wierzcho³ek podstawy

        // Wierzcho³ki podstawy
        for (int i = 0; i < segments; i++)
        {
            float angle = i * Mathf.PI * 2 / segments;
            vertices[i + 1] = new Vector3(Mathf.Cos(angle) * radius, position.y, Mathf.Sin(angle) * radius);
        }

        // Trójk¹ty podstawy
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = (i + 2 > segments) ? 1 : i + 2;
        }

        vertices[segments + 1] = new Vector3(0, height, 0) + position; // Wierzcho³ek szczytu sto¿ka
        // Wierzcho³ki œciany sto¿ka
        for (int i = segments + 1; i < 2 * segments + 1; i++)
        {
            float angle = (i - segments - 1) * Mathf.PI * 2 / segments;
            vertices[i + 1] = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius) + position;

        }
        //Trójk¹ty œciany sto¿ka
        for (int i = segments + 1; i < 2 * segments + 1; i++)
        {
            triangles[i * 3] = segments + 1;
            triangles[i * 3 + 1] = (i + 2 > 2 * segments) ? segments + 2 : i + 2;
            triangles[i * 3 + 2] = i + 1;
        }
    }

    private void Update()
    {
        meshRenderer.material.color = color;
    }
}
