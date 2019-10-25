using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{

    public GameObject[] blocks;
    public int rows;


    // Start is called before the first frame update
    void Start()
    {
        CreateBlocksGroup();
    }


    void CreateBlocksGroup()
    {
        float screenWidth, screenHeight, scaleMultiplier;
        int columns;
        float blockWidth = blocks[0].GetComponent<SpriteRenderer>().bounds.size.x; //x is our width
        float blochHeight = blocks[0].GetComponent<SpriteRenderer>().bounds.size.y;
        GetBlocksInformation(blockWidth, out screenWidth, out screenHeight, out columns, out scaleMultiplier);
        GameManager.totalNumberOfBlocks = rows * columns;

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                int randomIndex = Random.Range(0, blocks.Length);
                GameObject randomGo = blocks[randomIndex];
                GameObject instantiatedGo = (GameObject) Instantiate(randomGo);
                instantiatedGo.transform.position = new Vector3(-screenWidth / 2 + (blockWidth * scaleMultiplier * y),
                                                                screenHeight / 2 - (blochHeight * x),
                                                                0); //z become 0 as its 2 dimensional
                instantiatedGo.transform.localScale = new Vector3(instantiatedGo.transform.localScale.x * scaleMultiplier,
                                                                instantiatedGo.transform.localScale.y,
                                                                1); 
            }
        }
    }
    // Update is called once per frame
    void GetBlocksInformation(float blockwidth, out float screenWidth, out float screenHeight, out int columns,
        out float scaleMultiplier)
    {
        Camera cam = Camera.main;
        screenWidth = (cam.ScreenToWorldPoint (new Vector3(Screen.width,0,0)) -
            cam.ScreenToWorldPoint(new Vector3 (0,0,0))).x;
        screenHeight = (cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)) -
            cam.ScreenToWorldPoint(new Vector3(0, 0, 0))).y ;
        columns = (int)(screenWidth / blockwidth);
        scaleMultiplier = screenWidth / (blockwidth * columns); //mese to daftar neveshtam
    }
}
