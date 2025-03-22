using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comedToMayak : MonoBehaviour
{
    [SerializeField] private GameObject _checkedMayak;
    [SerializeField] private GameObject _sub3;
    [SerializeField] private AudioSource krasivoTut;
    [SerializeField] private GameObject _turnOnLever;
    public static bool ppp = true;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ppp)
        {
            _checkedMayak.SetActive(true);
            _sub3.SetActive(true);
            _turnOnLever.SetActive(true);
            krasivoTut.Play();
            ppp = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _checkedMayak.SetActive(true);
            _sub3.SetActive(false);
        }
    }
}
