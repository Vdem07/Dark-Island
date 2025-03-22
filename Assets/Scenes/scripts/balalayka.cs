using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balalayka : MonoBehaviour
{
    //[SerializeField] private AudioSource bal;
    [SerializeField] private AudioSource[] audioSources;
    public void PlayBalalayka()
    {
        int randomIndex = Random.Range(0, audioSources.Length);
        AudioSource selectedAudio = audioSources[randomIndex];

        selectedAudio.Play();
    }
   

}
