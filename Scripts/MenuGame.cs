using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for the Menu during the game and the action of each button
public class MenuGame : MonoBehaviour
{
    public GameObject control;
    public GameObject recepe;
    
    public void controls()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        control.GetComponent<Canvas>().enabled = true;
    }

    public void Recipe()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        recepe.GetComponent<Canvas>().enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
