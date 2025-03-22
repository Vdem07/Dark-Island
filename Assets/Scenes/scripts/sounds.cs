using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    protected AudioClip[] _sounds;
    
    private AudioSource _audioSource => GetComponent<AudioSource>();
    public void playSound(AudioClip clip, float volume = 0.5f)
    {
        _audioSource.PlayOneShot(clip, volume);
    }
}
