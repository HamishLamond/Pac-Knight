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
        //Loads the Pac-Knight walking audio clip from soundClips.
        GetComponent<AudioSource>().clip = soundClips[0];
        lastTime = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Plays the Pac-Knight walking audio clip every .5 seconds as long as nothing is already playing.
        timer += Time.deltaTime;
        if (timer > (lastTime + .5))
        {
            lastTime = timer;
            if (GetComponent<AudioSource>().isPlaying == false)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
