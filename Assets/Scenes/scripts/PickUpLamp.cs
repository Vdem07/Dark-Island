using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController123 : MonoBehaviour
{
    public GameObject lampPrefab; // Префаб лампы
    private GameObject currentLamp; // Текущая лампа, поднятая персонажем
    private Transform hand; // Трансформ руки персонажа

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

        // Логика включения/выключения света
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentLamp != null)
            {
                ToggleLight();
            }
        }
    }

    void PickUpLamp()
    {
        // Создаем лампу и помещаем ее в руку
        currentLamp = Instantiate(lampPrefab, hand);
        currentLamp.transform.localPosition = Vector3.zero;
        currentLamp.transform.localRotation = Quaternion.identity;

        // Отображаем руку и выключаем физику на лампе
        hand.gameObject.SetActive(true);
        isHoldingLamp = true;
        currentLamp.GetComponent<Rigidbody>().isKinematic = true;
    }

    void DropLamp()
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

    void ToggleLight()
    {
        Light lampLight = currentLamp.GetComponent<Light>();

        if (lampLight != null)
        {
            isLightOn = !isLightOn;
            lampLight.enabled = isLightOn;
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
        if (currentLamp != null && isLightOn)
        {
            ToggleLight();
        }
    }
}
