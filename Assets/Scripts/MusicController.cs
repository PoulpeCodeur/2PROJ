using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private bool autoPlay;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        PlayRandomMusic();
    }

    public void PlayRandomMusic()
    {
        if (!CanPlay) return;
        AudioClip clip = GetRandomMusic();
        source.clip = clip;
        source.PlayOneShot(clip);
    }

    private AudioClip GetRandomMusic()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    private bool CanPlay
    {
        get
        {
            bool result = clips != null && clips.Length > 0;
            if (!result) Debug.LogError("MusicController: No music clips assigned.");
            return result;
        }
    }
}