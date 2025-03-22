using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInSaray : MonoBehaviour
{
    public GameObject messageText; // Ссылка на текстовое поле с сообщением

   
 


    ///private bool isNearDoor = false;

    //public AudioSource DoorOpenSound;
    public AudioClip DoorOpenSound1;

    public void ChangeDoorState()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(DoorOpenSound1);
        messageText.SetActive(true);
    }
    public void ChangeDoorState2()
    {
        messageText.SetActive(false);
    }
    // Когда игрок входит в триггер зоны двери, отобразите сообщение
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
             // Включите текстовое поле
            //DoorOpenSound.Play();
            ChangeDoorState();
        }
    }

    // Когда игрок покидает триггер зону двери, скройте сообщение
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeDoorState2();
            //DoorOpenSound.Stop();
        }
    }
}
