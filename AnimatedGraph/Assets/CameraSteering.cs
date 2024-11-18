using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSteering : MonoBehaviour
{
    private float t;
    public float speed = 1f;
    public float radius = 2f;
    public float minHeight = -2f;
    public float maxHeight = 2f;
    public float liftSpeed = 1;
    private float currentHeight = -2f;
    private float direction = 1.0f;
    private float currentShiftX = 0;
    private float currentShiftZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        currentHeight = minHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentHeight += Time.deltaTime * liftSpeed;
            if (currentHeight > maxHeight) 
                currentHeight = maxHeight;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentHeight -= Time.deltaTime * liftSpeed;
            if (currentHeight < minHeight)
                currentHeight = minHeight;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
            t += Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
            t -= Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            currentShiftX+= Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            currentShiftX -= Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
            currentShiftZ += Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            currentShiftZ -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Z))
            radius += Time.deltaTime;

        if (Input.GetKey(KeyCode.X))
            radius -= Time.deltaTime;


        this.transform.position = new Vector3(radius * Mathf.Sin(t * speed)+currentShiftX, currentHeight, radius * Mathf.Cos(t * speed)+currentShiftZ);
        this.transform.LookAt(new Vector3(currentShiftX, currentShiftZ, 0));
    }
}
