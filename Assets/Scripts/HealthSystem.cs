using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    //Health
    public float playerHealth = 100;
    public PropertyMeter healthMeter;
    public float playerCurrentHealth = 0;

    //UI
    public Text gameOutputText;
    public Button restartButton;
    public Button quitButton;

    public GameObject player;
    public UIMenu menu;


    void Start()
    {
        playerCurrentHealth = playerHealth;
        
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        gameOutputText.gameObject.SetActive(false);


    }


    void Update()
    {
        GameOver();
    }

    //Damage
    public void TakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        float result = playerCurrentHealth / playerHealth;
        healthMeter.UpdateMeter(result);
    }

    public void GameOver()
    {
        if (playerCurrentHealth <= 0)
        {
            player.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            gameOutputText.gameObject.SetActive(true);
            gameOutputText.text = "Game Over";
        }
    }
    public void FellGameOver()
    {
        
        
            player.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            gameOutputText.gameObject.SetActive(true);
            gameOutputText.text = "Game Over";
        
    }
    public void RestartLevel()
    {
        playerCurrentHealth = 100;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
