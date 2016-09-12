using UnityEngine;

//Keeps track of score value throughout all scenes
public class ScoreHandler : MonoBehaviour {
    public static int score;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void Awake ()
    {
        score = 0;
        DontDestroyOnLoad(transform.gameObject);
    }
}
