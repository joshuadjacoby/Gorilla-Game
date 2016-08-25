﻿using UnityEngine;
using System.Collections;

public class Spawn_Stuff : MonoBehaviour
{

    public GameObject banana;

    Vector2 spawn_position;
    public double timer = 0.0;

    public GameObject[] kids = new GameObject[5];

    void spawn_item()
    {
        Vector3 screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector2[] pos = new Vector2[4] {new Vector2(screen.x * -.75f, .564f * screen.y), new Vector2(screen.x * -.25f, .564f * screen.y), new Vector2(screen.x * .25f, .564f * screen.y), new Vector2(screen.x * .75f, .564f * screen.y) };
        spawn_position = pos[Random.Range(0, 4)];
        if (Random.value > 0.7)
        {
            GameObject temp_spawn_kid = Instantiate(kids[Random.Range(0, 5)], spawn_position, Quaternion.identity) as GameObject;
            temp_spawn_kid.transform.localScale = new Vector2(screen.x * .0758f, screen.y * .05f);
        }
        else
        {
            GameObject temp_spawn_banana = Instantiate(banana, spawn_position, Quaternion.identity) as GameObject;
            temp_spawn_banana.transform.localScale = new Vector2(screen.x * .0264f, screen.y * .0174f);
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            spawn_item();
            timer = 0.0;
        }
    }
}