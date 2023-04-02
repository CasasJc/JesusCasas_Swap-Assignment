using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private int NewScore = 0;
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        //ScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        ScoreText.text = $"High Score: {GameManager.highScore}";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

}
