using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Displays score on different text objects for Main and Game Over scenes
public class ScoreDisplay : MonoBehaviour {
    Text text;

    public static int score;

    dreamloLeaderBoard dl;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();

        score = 0;

        if (SceneManager.GetActiveScene().name == "Game Over")
        {
            PlayerPrefs.SetInt("High Score", Mathf.Max(ScoreHandler.score, PlayerPrefs.GetInt("High Score")));
            text.text = "YOU GOT " + ScoreHandler.score + " BANANA" + ((ScoreHandler.score != 1) ? "S" : "") + "!\nBEST: " + PlayerPrefs.GetInt("High Score");
            ScoreHandler.score = 0;
        }

        dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        dl.AddScore(SystemInfo.deviceName, PlayerPrefs.GetInt("High Score"));
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main")
            text.text = ScoreHandler.score + "";
    }
}
