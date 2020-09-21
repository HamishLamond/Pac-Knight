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
        GetComponent<AudioSource>().clip = soundClips[0];
        lastTime = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > (lastTime + .5))
        {
            lastTime = timer;
            Debug.Log(lastTime);
            if (GetComponent<AudioSource>().isPlaying == false)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
