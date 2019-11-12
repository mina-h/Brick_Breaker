using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int points;
    public static int totalNumberOfBlocks;
    public GameObject canvas;
    public static GameManager instance;
    public Player player;
    public Ball ball;
    public Image stars;


    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        instance = this;
        canvas.SetActive(false);
    }

    public static void GameOver ()
    {
        //SceneManager.LoadScene("SampleScene");
        instance.canvas.SetActive(true);
        Destroy(instance.ball.gameObject);
       // Destroy(instance.player);
        instance.stars.fillAmount = points / (float)totalNumberOfBlocks;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
