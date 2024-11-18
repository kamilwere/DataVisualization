using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    private float t;
    public float speed = 1f;
    public float radius = 2f;
    public float minHeight = -2f;
    public float maxHeight = 2f;
    public float liftSpeed = 1;
    private float currentHeight = -2f;
    private float direction = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        currentHeight = minHeight;
    }

    // Update is called once per frame
    void Update()
    {
        t+= Time.deltaTime;
        currentHeight+=direction*Time.deltaTime*liftSpeed;
        if (currentHeight > maxHeight)
            direction = -1.0f;
        if (currentHeight < minHeight)
            direction = 1.0f;
        this.transform.position = new Vector3(radius*Mathf.Sin(t * speed), currentHeight, radius*Mathf.Cos(t * speed));
        this.transform.LookAt(new Vector3(0, 0, 0));
    }
}
