using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    private float xLimit;
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        float platformWidth = GetComponent<SpriteRenderer>().bounds.extents.x;  //the same as: bound.size.x / 2; o
        xLimit = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - platformWidth;
    }

        // Update is called once per frame
        void Update()
    {
        Transform t = GetComponent<Transform>();
        float mouseXmove = Input.GetAxis("Mouse X"); 
        t.position = t.position + (Vector3.right * mouseXmove * velocity * Time.deltaTime);
        float currentX = t.position.x;
        currentX = Mathf.Clamp(currentX, -xLimit, xLimit);
        t.position = new Vector3(currentX, t.position.y, t.position.z);  
        
    }
}
