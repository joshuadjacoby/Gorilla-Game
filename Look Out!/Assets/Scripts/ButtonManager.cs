using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    GameObject pauseButton;
    GameObject pauseText;
    GameObject quitButton;

    Sprite play;
    Sprite pause;

    bool gamePaused;

    void Awake ()
    {
        //if (SceneManager.GetActiveScene().name == "Start" && !PlayerPrefs.HasKey("Name"))
        //{

        //}
        //disables screen timeout
        if (SceneManager.GetActiveScene().name == "Main")
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        else
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }

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
        if (Input.GetKey(KeyCode.Menu))
            pauseGame();
        if (Input.GetKey(KeyCode.Escape) && gamePaused)
            pauseGame();
	}

    public void startGame () 
    {
        ScoreHandler.score = 0;
        SceneManager.LoadScene("Main");
    }

	public void pauseGame () 
	{
        if (gamePaused)
        {
            Time.timeScale = 1;
            pauseButton.GetComponent<Image>().sprite = pause;
            pauseText.SetActive(false);
            quitButton.SetActive(false);
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            gamePaused = false;
        }
        else
        {
            Time.timeScale = 0;
            pauseButton.GetComponent<Image>().sprite = play;
            pauseText.SetActive(true);
            quitButton.SetActive(true);
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
            gamePaused = true;
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
    
    void OnApplicationPause (bool pauseStatus)
    {
        if (pauseStatus && !gamePaused)
            pauseGame();
    }
}