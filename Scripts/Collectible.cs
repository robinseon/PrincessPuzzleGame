using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//play the aniamtion of the collectible when it is SetActive and stop the Animator at the end of the animation to just rotate the collectible
public class Collectible : MonoBehaviour
{
    Animator anima;
    Collider collid;
   
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        collid = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the game object that this script is attached to by 50 in the Y axis,
        // multiplied by deltaTime in order to make it per second rather than per frame.
        transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
        StartCoroutine("OnCompleteAnimation");
    }

    IEnumerator OnCompleteAnimation()//a coroutine to wait the end of the animation
    {
        while (anima.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;

        // TODO: Do something when animation did complete
        anima.enabled = false;
        collid.enabled = true;
    }
}
