using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioClip[] music;

    AudioSource audio;

    public void PlayMusic()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = music[0];
        audio.loop = false;
        audio.volume = 0.2f;
        audio.Play();
    }

    public void StopMusic()
    {
        audio.Stop();
    }

    public float GetTime()
    {
        return audio.time;
    }
}
