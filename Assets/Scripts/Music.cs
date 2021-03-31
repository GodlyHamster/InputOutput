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

    public float GetTime()
    {
        return audio.time;
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
        }
        audio.Stop();
    }
}
