using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ggg : MonoBehaviour
{
    private GameObject currentLamp; // Текущая лампа, поднятая персонажем
    private Transform hand; // Трансформ руки персонажа
    public Transform lampOrientationPoint;
    private bool isHoldingLamp = false; // Переменная для отслеживания поднятой лампы
    private bool isLightOn = false; // Переменная для отслеживания состояния света лампы

    void Start()
    {
        // Найдем и сохраним трансформ руки персонажа
        hand = transform.Find("Hand");

        // Спрячем руку при старте
        hand.gameObject.SetActive(false);
    }

    void Update()
    {
        // Логика поднятия лампы
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentLamp == null)
            {
                PickUpLamp();
            }
        }

        // Логика выбрасывания лампы
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentLamp != null)
            {
                DropLamp();
            }
        }

    }

    void PickUpLamp()
    {
        if (currentLamp == null)
        {
            // Найдите лампу в сцене (по имени, тегу или другому способу идентификации) и назначьте ее текущей лампой.
            currentLamp = GameObject.Find("oil_lamp"); // Здесь "Lamp" - это имя объекта лампы в сцене.

            if (currentLamp != null)
            {
                // Поднимаем лампу, делая "HandPosition" ее родителем
                currentLamp.transform.parent = transform.Find("HandPosition");

                // Отображаем руку и выключаем физику на лампе
                hand.gameObject.SetActive(true);
                isHoldingLamp = true;
                currentLamp.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }


    void DropLamp()
    {
        if (currentLamp != null)
        {
            // Выключаем руку и включаем физику на лампе
            hand.gameObject.SetActive(false);
            isHoldingLamp = false;
            currentLamp.GetComponent<Rigidbody>().isKinematic = false;

            // Бросаем лампу вперед
            currentLamp.GetComponent<Rigidbody>().AddForce(hand.forward * 5f, ForceMode.Impulse);

            // Убираем ссылку на текущую лампу
            currentLamp = null;
        }
    }


    // Сохранение состояния лампы при переходе между сценами
    public void SaveLampState()
    {
        PlayerPrefs.SetInt("IsHoldingLamp", isHoldingLamp ? 1 : 0);
        PlayerPrefs.SetInt("IsLightOn", isLightOn ? 1 : 0);
    }

    // Загрузка состояния лампы при переходе между сценами
    public void LoadLampState()
    {
        isHoldingLamp = PlayerPrefs.GetInt("IsHoldingLamp", 0) == 1;
        isLightOn = PlayerPrefs.GetInt("IsLightOn", 0) == 1;

        // Восстанавливаем состояние лампы
        if (isHoldingLamp)
        {
            PickUpLamp();
        }

    }
}
