using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for the ControlPanel and for the action of the buttonX
public class ControlsPanel : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject Menu;

    public void CancelButton()
    {
        StartMenu.GetComponent<Canvas>().enabled = true;
        Menu.GetComponent<Canvas>().enabled = true;
        gameObject.GetComponent<Canvas>().enabled = false;
    }
}
