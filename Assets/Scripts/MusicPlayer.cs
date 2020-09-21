using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] songs;

    // Start is called before the first frame update
    void Start()
    {
        //Plays the first song in the songs array.
        GetComponent<AudioSource>().clip = songs[0];
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        //If nothing is playing, play the second song in the songs array.
        if(GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().clip = songs[1];
            GetComponent<AudioSource>().Play();
        }
    }
}
