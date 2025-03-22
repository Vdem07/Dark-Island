using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


[AddComponentMenu("My components/Teleport")]
public class TeleporFromHouse : MonoBehaviour
{
    public GameObject messageText; // ������ �� ��������� ���� � ����������
    public int nextSceneNumber;   // ��� �����, ���� ����� �������

    private bool isNearDoor = false;

    private void Update()
    {
        // ���� ����� ��������� ����� � ������ � �������� ������� "E", ��������� �� ��������� �����
        if (isNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nextSceneNumber);
        }
    }

    // ����� ����� ������ � ������� ���� �����, ���������� ���������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageText.SetActive(true); // �������� ��������� ����
            isNearDoor = true;
        }
    }

    // ����� ����� �������� ������� ���� �����, ������� ���������
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageText.SetActive(false); // ��������� ��������� ����
            isNearDoor = false;
        }
    }
}



   
    
