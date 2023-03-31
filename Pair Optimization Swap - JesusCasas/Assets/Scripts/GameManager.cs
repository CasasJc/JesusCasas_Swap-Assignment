using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerCon player;
    public ParticleSystem explosionEffect;
    public AudioSource EnemyHitSound;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public int lives;
    public TextMeshProUGUI Livestext;

    public float InviciblilityTime = 3.0f;

    private void Start()
    {
        NewGame();
    }

   

    private void Update()
    {
        
    }

   public void NewGame()
   {
        player.transform.position = Vector3.zero;
        SetScore(0);
       SetLives(3);
       Respawn();
   }

    public void Respawn()
    {
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);

        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        Invoke(nameof(TurnOnCollision), this.InviciblilityTime);


    }

    void TurnOnCollision()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void AsteroidDestroyed(WormObj Worm)
    {
       explosionEffect.transform.position = Worm.transform.position;
        explosionEffect.Play();
        EnemyHitSound.Play();
        if (Worm.size < 0.7f)
        {
            SetScore(score + 100); // small Worm
        }
        else if (Worm.size < 1.4f)
        {
            SetScore(score + 50); // medium Worm
        }
        else
        {
            SetScore(score + 25); // large Worm
        }
    }

    public void PlayerDeath(PlayerCon player)
    {
        explosionEffect.transform.position = player.transform.position;
        explosionEffect.Play();

        SetLives(lives - 1);
        EnemyHitSound.Play();

        if (lives <= 0)
        {
            GameOver();
            
        }

        else
        {
            Invoke(nameof(Respawn), player.respawnDelay);
        }
    }

    public void GameOver()
    {
       
        SceneManager.LoadScene("MainMenu");

        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        

    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        Livestext.text = lives.ToString();
    }
}
