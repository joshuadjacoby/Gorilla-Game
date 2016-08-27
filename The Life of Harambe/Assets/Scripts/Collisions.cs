using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Collisions : MonoBehaviour {
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player" && gameObject.tag =="Enemy")
        {
            Destroy(col.gameObject);
            SceneManager.LoadScene("Start");
        }

        if (col.gameObject.tag == "Player" && gameObject.tag == "Collectable")
        {
            Destroy(gameObject);
            ScoreManager.score += 1;
        }
    }
}
