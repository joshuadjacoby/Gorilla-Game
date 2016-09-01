using UnityEngine;
using System.Collections;

public class SpawnStuff : MonoBehaviour
{

    GameObject banana;

    Vector2 spawn_position;
    double timer = 0.0;

    GameObject[] kids;

    GameObject temp_spawn_kid;
    GameObject temp_spawn_banana;

    public static int counter;
    double spawn_time;
    double spawn_freq;

    //Gets screen size and determines spawn positions accordingly
    Vector2 screen;
    Vector2[] pos;

    // Use this for initialization
    void Start()
    {
        banana = (GameObject)Resources.Load("Prefabs/Banana");

        kids = new GameObject[5] {
            (GameObject)Resources.Load("Prefabs/Kid 1"),
            (GameObject)Resources.Load("Prefabs/Kid 2"),
            (GameObject)Resources.Load("Prefabs/Kid 3"),
            (GameObject)Resources.Load("Prefabs/Kid 4"),
            (GameObject)Resources.Load("Prefabs/Kid 5")
        };

        counter = 0;
        spawn_time = 2;
        spawn_freq = .8;

        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        pos = new Vector2[4] { new Vector2(screen.x * -.75f, .564f * screen.y),
              new Vector2(screen.x * -.25f, .564f * screen.y),
              new Vector2(screen.x * .25f, .564f * screen.y),
              new Vector2(screen.x * .75f, .564f * screen.y)};
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawn_time)
        {
            spawn_item();
            timer = 0.0;
        }
        Debug.Log(spawn_freq);
    }

    void spawn_item()
    {
        spawn_position = pos[Random.Range(0, 4)];

        if (counter == 5)
        {
            counter = 0;
            if (spawn_time >= 1)
                spawn_time -= .1;
            if (spawn_freq >= .6)
                spawn_freq -= .02;
        }
        if (Random.value > spawn_freq)
        {
            temp_spawn_kid = Instantiate(kids[Random.Range(0, 5)], spawn_position, Quaternion.identity) as GameObject;
            temp_spawn_kid.transform.localScale = new Vector2(screen.x * .0758f, screen.y * .05f);
        }
        else
        {
            temp_spawn_banana = Instantiate(banana, spawn_position, Quaternion.identity) as GameObject;
            temp_spawn_banana.transform.localScale = new Vector2(screen.x * .0264f, screen.y * .0174f);
        }
    }
}
