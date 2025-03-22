using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class saray : MonoBehaviour
    {
        [SerializeField] private GameObject _ComedToSaray;
        [SerializeField] private GameObject _checkMayak;
        [SerializeField] private GameObject DontComeIntoMayak;
        [SerializeField] private GameObject _chekedLand;
        [SerializeField] private AudioSource axe_sound;
        [SerializeField] private GameObject axe_sub;
        [SerializeField] private GameObject back_to_home;
        [SerializeField] private GameObject axeAtHome;
        public static bool backeToHome = false;

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && tin.wasInTinZone == true)
            {
                _chekedLand.SetActive(true);
                axe_sub.SetActive(true);
                axe_sound.Play();
                axeAtHome.SetActive(true);
                back_to_home.SetActive(true);
                backeToHome = true;
                tin.wasInTinZone = false;
            }
        }
        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && ItemScript.isPickedUp == true)
            {
                DontComeIntoMayak.SetActive(false);
                _ComedToSaray.SetActive(true);
                _checkMayak.SetActive(true);
            }
            if (other.CompareTag("Player"))
            {
                axe_sub.SetActive(false);
            }

        }


    }
}
