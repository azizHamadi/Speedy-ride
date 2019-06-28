using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AudioScriptVoiture : MonoBehaviour
{
    public AudioClip MusicClilp;

    public AudioSource MusicSource;

    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClilp;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetAxisRaw("Horizontal") == 0)
        {
            MusicSource.Play();
        }

    }
}
