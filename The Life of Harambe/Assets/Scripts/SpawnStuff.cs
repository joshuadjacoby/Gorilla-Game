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

    void spawn_item()
    {
        Vector3 screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector2[] pos = new Vector2[4] {new Vector2(screen.x * -.75f, .564f * screen.y), new Vector2(screen.x * -.25f, .564f * screen.y), new Vector2(screen.x * .25f, .564f * screen.y), new Vector2(screen.x * .75f, .564f * screen.y) };
        spawn_position = pos[Random.Range(0, 4)];
        if (Random.value > 0.7)
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
