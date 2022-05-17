using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour
{
    public static LastDoor instance;
    AudioSource audioLastDoor;
    Animator anim;
    public int canInterract;
    public bool opened;
    bool oneTime=false;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        audioLastDoor = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Locker.instance.code == true)
        {
            if(oneTime==false)
            {
                anim.SetFloat("Open", 1);
                audioLastDoor.Play();
                opened = true;
                oneTime = true;
            }
        }
    }
}
