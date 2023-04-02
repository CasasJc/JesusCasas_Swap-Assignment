using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        //ScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore"); This doesn't update high score correcty
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
