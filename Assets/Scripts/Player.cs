using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public List<Transform> positions = new List<Transform>();
    private int currentPosition = 4;
    public float velocity;
    private float xLimit;
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        float platformWidth = GetComponent<SpriteRenderer>().bounds.extents.x;  //the same as: bound.size.x / 2; o
        xLimit = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - platformWidth;

        UpdatePosition();
    }


    public void OnLeftPressed()
    {
        if (currentPosition > 0)
        currentPosition--;
        UpdatePosition();
    }

    public void OnRightPressed()
    {
        if (currentPosition < positions.Count - 1)
        currentPosition++;
        UpdatePosition();

    }


    private void UpdatePosition()
    {
        transform.position = positions[currentPosition].position;

    }
    // Update is called once per frame
    void Update()

    {

        //limit the movement of the player
        float currentX = transform.position.x;
        currentX = Mathf.Clamp(currentX, -xLimit, xLimit);
        //apply it to the new position (new x,y,z)
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);

    }

    }

