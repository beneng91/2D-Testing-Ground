using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public Text gameOutputText;

    public Button startButton;
    public Button restartButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        GameSetUp();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GameSetUp()
    {
        gameOutputText.text = "Hello World!";
        startButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
        Debug.Log ("button is working");


    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
