using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] songs;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = songs[0];
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().clip = songs[1];
            GetComponent<AudioSource>().Play();
        }
    }
}
