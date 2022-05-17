using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//action for the buttons at the beginning of tha game
public class StartGameMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraAroundIslande;
    public GameObject control;
    public GameObject recepe;
    public GameObject Inventory;
    public GameObject Crafting;
    public GameObject Canvas;
    public GameObject Tools;
    public GameObject Menu;
    bool menuDisplay=false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuDisplay = !menuDisplay;
            if (menuDisplay)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Inventory.SetActive(false);
                Crafting.SetActive(false);
                Canvas.SetActive(false);
                Tools.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Inventory.SetActive(true);
                Crafting.SetActive(true);
                Canvas.SetActive(true);
                Tools.SetActive(true);
            }
            gameObject.GetComponent<Canvas>().enabled = menuDisplay;
        }
    }
    public void play()
    {
        player.SetActive(true);
        cameraAroundIslande.SetActive(false);
        //gameObject.GetComponent<Canvas>().enabled = false;
        menuDisplay = false;
        player.GetComponent<Action>().stopMove = false;
        player.GetComponent<Action>().craftingMoment = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Inventory.SetActive(true);
        Crafting.SetActive(true);
        Canvas.SetActive(true);
        Tools.SetActive(true);
        Menu.GetComponent<Canvas>().enabled=true;
        Menu.SetActive(false);
        gameObject.SetActive(false);
    }

    public void controls()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        control.GetComponent<Canvas>().enabled=true;
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
