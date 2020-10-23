using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSoundPlayer : MonoBehaviour
{
    public AudioClip[] soundClips;
    private float lastTime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlaySound(int soundClipNumber)
    {
        GetComponent<AudioSource>().clip = soundClips[soundClipNumber];
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void StopSound()
    {
        GetComponent<AudioSource>().clip = null;
    }
}
