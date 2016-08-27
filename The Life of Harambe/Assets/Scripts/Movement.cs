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

        player = GameObject.Find("Harambe");

        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update()
    {
		if ((moveLeft && !moveRight) || Input.acceleration.x < 0)
        {
            if (!(player.transform.position.x < -screen.x * .74))
                player.GetComponent<Rigidbody2D>().velocity = -forwardSpeed;
            else
                StopMeLeft();
        }
		if ((moveRight && !moveLeft) || Input.acceleration.x > 0)
        {
            if (!(player.transform.position.x > screen.x * .74))
                player.GetComponent<Rigidbody2D>().velocity = forwardSpeed;
            else
                StopMeRight();
        }
    }

    public void MoveMeLeft()
    {
        moveLeft = true;
    }

    public void StopMeLeft()
    {
        moveLeft = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void MoveMeRight()
    {
        moveRight = true;
    }

    public void StopMeRight()
    {
        moveRight = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
