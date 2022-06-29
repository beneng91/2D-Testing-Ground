using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    public Text gameOutputText;

    private void OnTriggerEnter(Collider other)
    {
        gameOutputText.gameObject.SetActive(true);
        gameOutputText.text = "A and D to move left and right. \nSpace to jump. \nLeft mouse click to attack. \nDouble click to combo attack.";

    }

    private void OnTriggerExit(Collider other)
    {
        gameOutputText.gameObject.SetActive(false);
    }
}
