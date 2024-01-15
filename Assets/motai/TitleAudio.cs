using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudio : MonoBehaviour
{
    private new AudioSource audio;
    float volume = 0.2f;
    bool Is_Audio = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("A"))
        {
            Is_Audio = true;
        }

        if(Is_Audio)
        {
            audio.volume -= Time.deltaTime * volume;
        }
    }
}
