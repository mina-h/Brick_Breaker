using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public Camera cam;
    public EdgeCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 upperLeft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector3 upperRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 bottomRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        collider.points = new Vector2[5] { bottomLeft, upperLeft, upperRight, bottomRight, bottomLeft };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
