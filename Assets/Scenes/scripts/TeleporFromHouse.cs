using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


[AddComponentMenu("My components/Teleport")]
public class TeleporFromHouse : MonoBehaviour
{
    public GameObject messageText; // Ссылка на текстовое поле с сообщением
    public int nextSceneNumber;   // Имя сцены, куда нужно перейти

    private bool isNearDoor = false;

    private void Update()
    {
        // Если игрок находится рядом с дверью и нажимает клавишу "E", перейдите на следующую сцену
        if (isNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nextSceneNumber);
        }
    }

    // Когда игрок входит в триггер зоны двери, отобразите сообщение
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageText.SetActive(true); // Включите текстовое поле
            isNearDoor = true;
        }
    }

    // Когда игрок покидает триггер зону двери, скройте сообщение
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageText.SetActive(false); // Выключите текстовое поле
            isNearDoor = false;
        }
    }
}



   
    
