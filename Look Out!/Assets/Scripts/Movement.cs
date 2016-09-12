using UnityEngine;

public class Movement : MonoBehaviour
{

    bool moveLeft;
    bool moveRight;

    Vector2 forwardSpeed;

    GameObject player;
	
    Vector3 screen;

    void Start()
    {
		forwardSpeed = new Vector2(5, 0);

        player = GameObject.Find("Gorilla");

        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void FixedUpdate()
    {
        if (Input.acceleration.x < 0 && !(player.transform.position.x < -screen.x * .74))
            player.transform.Translate(Mathf.Max(Input.acceleration.x, -.15f), 0, 0);
        else if (Input.acceleration.x > 0 && !(player.transform.position.x > screen.x * .74))
            player.transform.Translate(Mathf.Min(Input.acceleration.x, .15f), 0, 0);
        else
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        getDirection();

        if (moveLeft && !moveRight)
        {
            if (!(player.transform.position.x < -screen.x * .74))
                player.GetComponent<Rigidbody2D>().velocity = -forwardSpeed;
            else
                StopMeLeft();
        }
        if (moveRight && !moveLeft)
        {
            if (!(player.transform.position.x > screen.x * .74))
                player.GetComponent<Rigidbody2D>().velocity = forwardSpeed;
            else
                StopMeRight();
        }
    }

    //Determines the players x direction
    void getDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            MoveMeLeft();
        else
            StopMeLeft();
        if (Input.GetKey(KeyCode.RightArrow))
            MoveMeRight();
        else
            StopMeRight();
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
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
