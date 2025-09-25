using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncController : MonoBehaviour
{
    [HideInInspector]
    public float audioTime;

    public AudioSource audioSource;

    public void Play()
    {
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void Init(AudioClip clip)
    {
        audioSource.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying)
        {
            audioTime += (Time.deltaTime) * Mathf.Clamp(audioSource.pitch, 0, 9999f);
        }
    }
}
