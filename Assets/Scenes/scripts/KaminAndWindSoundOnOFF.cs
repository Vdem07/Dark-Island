using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaminAndWindSoundOnOFF : MonoBehaviour
{
    [SerializeField] private AudioSource _wind;
    [SerializeField] private AudioSource _kamin;
    [SerializeField] private GameObject _ComeToHome;
    [SerializeField] private GameObject _checkHome;
    public static bool inHome;
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ComeToHome.SetActive(true);
            _checkHome.SetActive(true);
            _kamin.Play();
            _wind.volume = 0.01f;         
            inHome = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _kamin.Stop();
            _wind.volume = 0.05f;
            inHome = false;
        }

    }

}
