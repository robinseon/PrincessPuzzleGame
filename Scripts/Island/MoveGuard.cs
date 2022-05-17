using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGuard : MonoBehaviour
{
    public static MoveGuard instance;
    float distanceWithStone=30;
    Vector3 positionStone = new Vector3(0, 30, 0);
    Vector3 guard;
    public bool initialPosition;
    Animator anim;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        guard = transform.position;
    }

    void Update()
    {
        if (distanceWithStone <= 20)
        {
            transform.LookAt(positionStone);
            anim.SetFloat("Walk", 1);
            if (-0.1f > (transform.position.z - positionStone.z) || (transform.position.z - positionStone.z) > 0.1f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime);
                initialPosition = false;
            }
            if (-0.1f < (transform.position.z - positionStone.z) && (transform.position.z - positionStone.z) < 0.1f)
            {
                distanceWithStone = 30;
                StartCoroutine("WaitTwoSeconds");

            }
        }
        else
        {
            anim.SetFloat("Walk", 0);
            if (-0.1f < (transform.position.z - guard.z) && (transform.position.z - guard.z) < 0.1f)
            { 
                initialPosition = true;
                transform.eulerAngles = new Vector3(0, 142, 0);
            }
        }
    }

    public void GetDistance(GameObject stone)
    {
        distanceWithStone = Distance.instance.CalculateDistance(stone);
    }

    public void GetPositionStone(GameObject stone)
    {
        positionStone = stone.transform.position;
        positionStone.y = 30.0f;
    }

    IEnumerator WaitTwoSeconds() //Have to wait to start the animation befor to use the Coroutine because the normalizedTime has +1 each animation
    {
        yield return new WaitForSeconds(2);
        if(initialPosition==false)
        {
            distanceWithStone = 1;
            positionStone = guard;
        }
    }
}
