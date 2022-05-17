using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTree : MonoBehaviour
{
    public Animator animCut;
    Animator anim;
    Collider collid;
    public GameObject collectible;
    public AudioClip audioCut;
    public AudioClip audioFall;
    public AudioSource audioTree;

    public int canInterract = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        collid = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (canInterract == 1 && DisplayUsableItems.instance.inTheHand.id==10)//to choose the good tree to cut
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                audioTree.clip = audioCut;
                audioTree.Play();
                StartCoroutine("WaitThreeSeconds");
                animCut.SetTrigger("Cut");
            }
        }

        // Debug.Log(temps);
    }

    IEnumerator OnCompleteAnimation()
    {
        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;

        // TODO: Do something when animation did complete;
        collectible.SetActive(true);
        gameObject.SetActive(false);
        audioTree.volume = 0.181f;
    }
    IEnumerator WaitToStartAnimation() //Have to wait to start the animation befor to use the Coroutine because the normalizedTime has +1 each animation
    {
        yield return new WaitForSeconds(1);
        StartCoroutine("OnCompleteAnimation");
    }

    IEnumerator WaitThreeSeconds() 
    {
        yield return new WaitForSeconds(3);
        collid.enabled = false;
        audioTree.clip = audioFall;
        audioTree.volume = 0.05f;
        audioTree.Play();
        anim.SetFloat("Fall", 1.0f);
        StartCoroutine("WaitToStartAnimation");
    }
}
