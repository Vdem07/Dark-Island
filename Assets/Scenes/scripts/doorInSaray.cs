using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInSaray : MonoBehaviour
{
    public GameObject messageText; // ������ �� ��������� ���� � ����������

   
 


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
    // ����� ����� ������ � ������� ���� �����, ���������� ���������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
             // �������� ��������� ����
            //DoorOpenSound.Play();
            ChangeDoorState();
        }
    }

    // ����� ����� �������� ������� ���� �����, ������� ���������
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeDoorState2();
            //DoorOpenSound.Stop();
        }
    }
}
