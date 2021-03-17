using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioClip[] music;
    
    void PlayMusic()
    {
        AudioSource audio;
        audio = GetComponent<AudioSource>();
        audio.clip = music[0];
        audio.loop = false;
        audio.volume = 0.07f;
        audio.Play();
    }
}
