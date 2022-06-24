using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGoal : MonoBehaviour
{
    public Text gameOutputText;

    public Button restartButton;
    public Button quitButton;
    public GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        player.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        gameOutputText.gameObject.SetActive(true);
        gameOutputText.text = "You win!";
    }

}
