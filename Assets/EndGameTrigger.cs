using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EndGameScreen;
    public GameObject playerUI;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EndGameScreen.SetActive(true);
            EndGameScreen.GetComponent<Animator>().enabled = true;
            EndGameScreen.GetComponent<Animator>().Play("FinalScreenFadeIn");
            Cursor.visible = true;
            playerUI.SetActive(false);
        }
    }
}
