using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for the actions of the buttons YES and NO for the panel which is opened when the button Recipe from the menu is pressed
public class RecipeAreYouSure : MonoBehaviour
{
    public GameObject recipe;
    public GameObject StartMenu;
    public GameObject Menu;
    public void YesButton()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        recipe.GetComponent<Canvas>().enabled = true;
    }

    public void NoButton()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        Menu.GetComponent<Canvas>().enabled = true;
        StartMenu.GetComponent<Canvas>().enabled = true;
    }
}
