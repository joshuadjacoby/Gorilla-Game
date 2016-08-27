using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playGame () 
    {
        SceneManager.LoadScene("Main");
    }

	public void pauseGame() 
	{
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		else
			Time.timeScale = 0;
	}
}