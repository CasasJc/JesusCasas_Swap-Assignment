using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class MenuManager : MonoBehaviour
{
    private int NewScore = 0;
    public TextMeshProUGUI ScoreText;
    
    void Start()
    {
        ScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    
    void Update()
    {
     
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
