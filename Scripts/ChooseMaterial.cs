using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//choose the material in the inventory for the crafting panel
public class ChooseMaterial : MonoBehaviour
{
    public static ChooseMaterial instance;
    public int select;
    AudioSource audioSelect;
    
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSelect = GetComponent<AudioSource>();
    }
    public void Selection()//return the index of the material and play the song
    {
        //save the select
        select = transform.GetSiblingIndex();
        //play song
        audioSelect.Play();
        //Change image
        CraftingPartTest.instance.AddItem(select);
    }
}
