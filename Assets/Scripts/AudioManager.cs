using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script used to manage the global audio of the game, so the prison and island song
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public int indexAudio;
    public bool islandeSong;
    public bool prisonSong;
    bool oneTime;
    public AudioClip playlist;
    public AudioClip islande;
    public AudioClip prison;
    public AudioSource audiosource;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()//star with the islande song
    {
        audiosource.clip = playlist;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (LastDoor.instance.opened == true)//if it is the last door, play the song one time because with Play(), the song restart
        {
            if(oneTime==false)
            {
                audiosource.clip = islande;
                audiosource.Play();
            }
        }

    }

    public void ChangeMusic()//use when the Play Button is pressed, to start the Island song
    {
        if (islandeSong == false && prisonSong==false)
        {
            audiosource.clip = islande;
            audiosource.Play();
            islandeSong = true;
        }      
    }

    public void RespawnMusic()//Change the music when the player die, with the Islande music
    {
        audiosource.clip = islande;
        audiosource.volume = 0.05f;
        audiosource.Play();
        islandeSong = true;
        prisonSong = false;
    }


    public void OnTriggerEnter(Collider other)//to change the song when the player enter or leave the prison
    {
        if(other.CompareTag("Player"))
        {
            if(islandeSong)
            {
                audiosource.clip = prison;
                audiosource.volume = 0.4f;
                audiosource.Play();
                prisonSong = true;
                islandeSong = false;
            }
            else if(prisonSong)
            {
                audiosource.clip = islande;
                audiosource.volume = 0.05f;
                audiosource.Play();
                prisonSong = false;
                islandeSong = true;
            }
        }
    }
}
