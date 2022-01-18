using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float ballSpeed;
    Rigidbody rb;
    bool gameStarted;
    bool gameOver;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameStarted = false;
        gameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-4.5f, 4.5f),0,Random.Range(-4.5f, 4.5f));
        //rb.velocity = new Vector3(ballspeed,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            { 
                  rb.velocity = new Vector3(ballSpeed,0,0);
                gameStarted = true;
            }
            
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            rb.velocity = new Vector3(0, -25f, 0);
            gameOver = true;
            //print("Platform!!");
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.cyan);
        
            if (Input.GetMouseButtonDown(0) && !gameOver)
            {
                ChangeBallDirection();
            }

        

        
    }

    void ChangeBallDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(ballSpeed,0,0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0,0,ballSpeed);
        }
    }
}
