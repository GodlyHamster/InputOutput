using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Music : MonoBehaviour
{

    AudioSource audio;

    public void PlayMusic(string clipName)
    {
        audio = GetComponent<AudioSource>();
        audio.clip = Resources.Load("Music/" + clipName) as AudioClip;
        audio.loop = false;
        audio.volume = 0.2f;
        audio.Play();
    }

    public float GetTime()
    {
        return audio.time;
    }

    public float GetSongLength()
    {
        return audio.clip.length;
    }

    public void SetTime(float timeStamp)
    {
        audio.time = timeStamp;
    }

    public IEnumerator StopMusic()
    {
        for (int i = 0; i < 100; i++)
        {
            if (audio.pitch > 0)
            {
                audio.pitch -= 0.01f;
                yield return new WaitForSeconds(0.02f);
            }
            else
            {
                audio.pitch = 0;
            }
        }
        audio.Stop();
    }
}
