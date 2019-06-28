using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AudioScript : MonoBehaviour
{

    public AudioClip MusicClilp;

    public AudioSource MusicSource;
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClilp;
        MusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
