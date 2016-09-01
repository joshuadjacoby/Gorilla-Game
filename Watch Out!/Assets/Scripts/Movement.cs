using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    private bool moveLeft;
    private bool moveRight;

	Vector2 forwardSpeed;

    GameObject player;
	
    Vector3 screen;

    void Start()
    {
		forwardSpeed = new Vector2(5, 0);

        player = GameObject.Find("Gorilla");

        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update()
    {
        getDirection();
        if (moveLeft && !moveRight)
        {
            if (!(player.transform.position.x < -screen.x * .74))
                player.transform.Translate(Mathf.Max(Input.acceleration.x, -.15f), 0, 0);
            //player.GetComponent<Rigidbody2D>().velocity = -forwardSpeed;
            else
                StopMeLeft();
        }
		if (moveRight && !moveLeft)
        {
            if (!(player.transform.position.x > screen.x * .74))
                player.transform.Translate(Mathf.Min(Input.acceleration.x, .15f), 0, 0);
            //player.GetComponent<Rigidbody2D>().velocity = forwardSpeed;
            else
                StopMeRight();
        }
    }
    
    //Determines the players x direction
    void getDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.acceleration.x < 0)
            MoveMeLeft();
        else
            StopMeLeft();
        if (Input.GetKey(KeyCode.RightArrow) || Input.acceleration.x > 0)
            MoveMeRight();
        else
            StopMeRight();
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void MoveMeLeft()
    {
        moveLeft = true;
    }

    void StopMeLeft()
    {
        moveLeft = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void MoveMeRight()
    {
        moveRight = true;
    }

    void StopMeRight()
    {
        moveRight = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
