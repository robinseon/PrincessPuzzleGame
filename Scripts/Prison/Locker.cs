using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    public static Locker instance;
    public bool code;
    public GameObject player;
    AudioSource audioLocker;
    public AudioSource audioValidate;
    public AudioClip goodPassword;
    public AudioClip wrongPassword;
    public int firstDig=0, secondDig=0, thirdDig=0, fourthDig = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        code = false;
        audioLocker = GetComponent<AudioSource>();
    }

    public void addFirstDig()
    {
        if (firstDig < 9)
            firstDig++;
        else
            firstDig = 0;
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = firstDig.ToString();
    }
    public void addSecondDig()
    {
        if (secondDig < 9)
            secondDig++;
        else
            secondDig = 0;
        transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = secondDig.ToString();
    }
    public void addThirdDig()
    {
        if (thirdDig < 9)
            thirdDig++;
        else
            thirdDig = 0;
        transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Text>().text = thirdDig.ToString();
    }
    public void addFourthDig()
    {
        if (fourthDig < 9)
            fourthDig++;
        else
            fourthDig = 0;
        transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = fourthDig.ToString();
    }

    public void reduceFirstDig()
    {
        if (firstDig > 0)
            firstDig--;
        else
            firstDig = 9;
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = firstDig.ToString();
    }

    public void reduceSecondtDig()
    {
        if (secondDig > 0)
            secondDig--;
        else
            secondDig = 9;
        transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = secondDig.ToString();
    }
    public void reduceThirdtDig()
    {
        if (thirdDig > 0)
            thirdDig--;
        else
            thirdDig = 9;
        transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Text>().text = thirdDig.ToString();
    }
    public void reduceFourthDig()
    {
        if (fourthDig > 0)
            fourthDig--;
        else
            fourthDig = 9;
        transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = fourthDig.ToString();
    }

    public void validateCode()
    {
        if (firstDig == 0 && secondDig == 9 && thirdDig == 2 && fourthDig == 9)
        {
            code = true;
            audioValidate.clip = goodPassword;
            audioValidate.Play();
            transform.GetComponent<Canvas>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            code = false;
            audioValidate.clip = wrongPassword;
            audioValidate.Play();
        }      
    }

    public void cancel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.GetComponent<Canvas>().enabled = false;
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = "0";
        transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = "0";
        transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = "0";
        transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Text>().text = "0";
        firstDig = 0;
        secondDig = 0;
        thirdDig = 0;
        fourthDig = 0;
        audioLocker.Play();
        player.GetComponent<Action>().stopMove = false;
    }
}
