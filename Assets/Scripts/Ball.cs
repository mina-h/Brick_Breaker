using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float velocity = 1;
    private Vector3 direction;
    public GameObject starParticles, brickParticles;


    // Start is called before the first frame update
    void Start()
    {
        //create a random value between 1 and -1
        float randomValue = Random.Range(-1f, 1f);
        //asign it to x value
        float xComponent = Mathf.Sign(randomValue);
        //going to upward direction
        direction = new Vector3(xComponent, 1, 0);
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position += (direction * velocity * Time.deltaTime);   
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        //ButtonInput buttonInput = collider.gameObject.GetComponent<ButtonInput>();
        Collider collider1 = collider.gameObject.GetComponent<Collider>();
        Player player = collider.gameObject.GetComponent<Player>();
        Vector2 normal = collider.contacts[0].normal;
        bool isGameOver = false;

        if (collider1 != null) //if it hits the collider
        {
            if(normal == Vector2.up) //short form of (0,1))
            {
                isGameOver = true;
            }
            
        }
        else if (player)
        {
            starParticles.transform.position = player.transform.position;
            starParticles.GetComponent<ParticleSystem>().Play();
            player.GetComponent<Animator>().SetTrigger("isCollidingWithBall");
            player.GetComponent<AudioSource>().Play();

            if(normal != Vector2.up)
            {
                isGameOver = true;
            }
        }
        else //if (buttonInput != null)
        {
            SpriteRenderer renderer = collider.gameObject.GetComponent<SpriteRenderer>();
            Vector3 brickPosition = collider.gameObject.transform.position;
            Vector3 particleInstantiationPoint = new Vector3(brickPosition.x + renderer.bounds.extents.x,
                                                             brickPosition.y - renderer.bounds.extents.y,
                                                             -1); //extend is half the size
            GameObject ourParticles = (GameObject)Instantiate(brickParticles, particleInstantiationPoint , Quaternion.identity); //quaternion.identity means no rotation))

            ParticleSystem particleSystem = ourParticles.GetComponent<ParticleSystem>();

            //destrpying the blocks and the particles
            Destroy(collider.gameObject);
            Destroy(ourParticles, particleSystem.main.startLifetimeMultiplier + particleSystem.main.duration); //the time  u destroy anything t seconds after calling the method
            GameManager.points++;
            GetComponent<AudioSource>().Play();
        }

        if (isGameOver)
        {
            GameManager.GameOver();
        }
        else
        {
            Vector3.Reflect(direction, collider.contacts[0].normal);
            direction = Vector3.Reflect(direction, collider.contacts[0].normal);
            direction.Normalize();

        }

    }
}
