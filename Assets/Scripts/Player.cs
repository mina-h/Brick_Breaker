using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public float xLimit;
    // Start is called before the first frame update
    void Start()
    {
        
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
