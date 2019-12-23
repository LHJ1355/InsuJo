using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip sound;
    AudioSource myaudio;

    public static SoundManager instance;
    // Start is called before the first frame update

    void Awake()
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
    }

    void Start()
    {
        myaudio = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        myaudio.PlayOneShot(sound);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
