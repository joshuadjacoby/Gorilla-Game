using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Collisions : MonoBehaviour {
    Text text;
    // Use this for initialization
    void Start ()
    {
        text = GetComponent<Text>();
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
            SceneManager.LoadScene("Main");
        }

        if (col.gameObject.tag == "Player" && gameObject.tag == "Collectable")
        {
            Destroy(gameObject);
            text.GetComponent<ScoreManager>().addScore(1);
        }
    }
}
