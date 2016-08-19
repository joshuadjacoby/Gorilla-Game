using UnityEngine;
using System.Collections;

public class Spawn_Stuff : MonoBehaviour
{

    public GameObject banana;

    Vector3 spawn_position;
    public double timer = 0.0;

    public GameObject[] kids = new GameObject[5];

    void spawn_item()
    {
        float[] pos = new float[] { -2, 0, 2 };
        spawn_position = new Vector3(pos[Random.Range(0, 3)], 2.6f, 0);
        if (Random.value > 0.7)
        {
            GameObject temp_spawn_kid = Instantiate(kids[Random.Range(0, 5)], spawn_position, Quaternion.identity) as GameObject;
        }
        else
        {
            GameObject temp_spawn_banana = Instantiate(banana, spawn_position, Quaternion.identity) as GameObject;
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
