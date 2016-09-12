using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    GameObject pauseButton;
    GameObject pauseText;
    GameObject quitButton;

    Sprite play;
    Sprite pause;

	// Use this for initialization
	void Start ()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            pauseButton = GameObject.Find("Pause Button");
            pauseText = GameObject.Find("Pause Text");
            pauseText.SetActive(false);
            quitButton = GameObject.Find("Quit Button");
            quitButton.SetActive(false);

            play = Resources.Load<Sprite>("Play");
            pause = Resources.Load<Sprite>("Pause");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void startGame () 
    {
        ScoreHandler.score = 0;
        SceneManager.LoadScene("Main");
    }

	public void pauseGame () 
	{
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseButton.GetComponent<Image>().sprite = pause;
            pauseText.SetActive(false);
            quitButton.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseButton.GetComponent<Image>().sprite = play;
            pauseText.SetActive(true);
            quitButton.SetActive(true);
        }
	}

    public void quitGame ()
    {
        pauseGame();
        SceneManager.LoadScene("Start");
    }

    public void newGame ()
    {
        SceneManager.LoadScene("Main");
        GameObject.Find("AdMobHandler").GetComponent<AdMob>().bannerHide();
    }
}