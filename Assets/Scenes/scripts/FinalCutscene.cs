using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class FinalCutscene : MonoBehaviour
    {
        //[SerializeField] private GameObject _back_to_home_sub;
        [SerializeField] private GameObject _back_to_home_cheked;
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && saray.backeToHome == true)
            {
                //_back_to_home_sub.SetActive(true);
                _back_to_home_cheked.SetActive(true);
                //_back_to_home_sound.Play();
                saray.backeToHome = false;
                CutsceneManager.Instance.StartCutscene("cut2");
            }
        }
    }
}