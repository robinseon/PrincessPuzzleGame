using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//action for th erecipe panel, for the XButton and the >Button
public class Recipes : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject Menu;
    public GameObject NextRecipe;

    public void CancelButton()
    {
        StartMenu.GetComponent<Canvas>().enabled = true;
        Menu.GetComponent<Canvas>().enabled = true;
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void OverRecipe()
    {
        NextRecipe.GetComponent<Canvas>().enabled = true;
        gameObject.GetComponent<Canvas>().enabled = false;
    }
}
