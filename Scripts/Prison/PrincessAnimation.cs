using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessAnimation : MonoBehaviour
{
    Animator anim;
    public GameObject congratulation;
    bool oneTime=false;
    public AudioSource audioManager;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(LastDoor.instance.opened==true)
        {
            if(oneTime==false)
            {
                StartCoroutine("WaitOneSecond");
                oneTime = true;
            }
        }
    }
    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Happy");
        congratulation.SetActive(true);
        audioManager.volume = 0.2f;
    }
}
