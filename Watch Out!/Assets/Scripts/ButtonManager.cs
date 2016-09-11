using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonManager : MonoBehaviour {
    GameObject pauseButton;

    Sprite play;
    Sprite pause;

	// Use this for initialization
	void Start ()
    {
        pauseButton = GameObject.Find("Pause Button");

        play = Resources.Load<Sprite>("Play");
        pause = Resources.Load<Sprite>("Pause");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void startGame () 
    {
        SceneManager.LoadScene("Main");
    }

	public void pauseGame () 
	{
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseButton.GetComponent<Image>().sprite = pause;
        }
        else
        {
            Time.timeScale = 0;
            pauseButton.GetComponent<Image>().sprite = play;
        }
	}

    public void newGame ()
    {
        SceneManager.LoadScene("Main");
        GameObject.Find("AdMobHandler").GetComponent<AdMob>().bannerHide();
    }
}