using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class tin : MonoBehaviour
    {
        [SerializeField] private GameObject tinOnFloor;
        [SerializeField] private GameObject lookAtHome;
        [SerializeField] private AudioSource surprisedTin;
        [SerializeField] private GameObject osmotrLand;
        [SerializeField] private GameObject axeAtSaray;
        public static bool wasInTinZone = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && DAY2.tin == false)
            {

                tinOnFloor.SetActive(true);
                lookAtHome.SetActive(true);
                surprisedTin.Play();
                osmotrLand.SetActive(true);
                wasInTinZone = true;
                axeAtSaray.SetActive(false);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && DAY2.tin == false)
            {
                DAY2.tin = true;
                tinOnFloor.SetActive(false);
            }
        }
    }
}
