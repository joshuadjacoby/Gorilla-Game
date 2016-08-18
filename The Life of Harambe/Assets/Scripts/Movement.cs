using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    private bool moveLeft;
    private bool moveRight;

    Vector2 forwardSpeed = new Vector2(5, 0);

    GameObject player;

    void Start()
    {
        player = GameObject.Find("Harambe");
    }

    void Update()
    {
        if (moveLeft && !moveRight)
        {
            if (!(player.transform.position.x < -2))
                player.GetComponent<Rigidbody2D>().velocity = -forwardSpeed;
            else
                StopMeLeft();
        }
        if (moveRight && !moveLeft)
        {
            if (!(player.transform.position.x > 2))
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
