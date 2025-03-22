using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController123 : MonoBehaviour
{
    public GameObject lampPrefab; // ������ �����
    private GameObject currentLamp; // ������� �����, �������� ����������
    private Transform hand; // ��������� ���� ���������

    private bool isHoldingLamp = false; // ���������� ��� ������������ �������� �����
    private bool isLightOn = false; // ���������� ��� ������������ ��������� ����� �����

    void Start()
    {
        // ������ � �������� ��������� ���� ���������
        hand = transform.Find("Hand");

        // ������� ���� ��� ������
        hand.gameObject.SetActive(false);
    }

    void Update()
    {
        // ������ �������� �����
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentLamp == null)
            {
                PickUpLamp();
            }
        }

        // ������ ������������ �����
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentLamp != null)
            {
                DropLamp();
            }
        }

        // ������ ���������/���������� �����
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
        // ������� ����� � �������� �� � ����
        currentLamp = Instantiate(lampPrefab, hand);
        currentLamp.transform.localPosition = Vector3.zero;
        currentLamp.transform.localRotation = Quaternion.identity;

        // ���������� ���� � ��������� ������ �� �����
        hand.gameObject.SetActive(true);
        isHoldingLamp = true;
        currentLamp.GetComponent<Rigidbody>().isKinematic = true;
    }

    void DropLamp()
    {
        // ��������� ���� � �������� ������ �� �����
        hand.gameObject.SetActive(false);
        isHoldingLamp = false;
        currentLamp.GetComponent<Rigidbody>().isKinematic = false;

        // ������� ����� ������
        currentLamp.GetComponent<Rigidbody>().AddForce(hand.forward * 5f, ForceMode.Impulse);

        // ������� ������ �� ������� �����
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

    // ���������� ��������� ����� ��� �������� ����� �������
    public void SaveLampState()
    {
        PlayerPrefs.SetInt("IsHoldingLamp", isHoldingLamp ? 1 : 0);
        PlayerPrefs.SetInt("IsLightOn", isLightOn ? 1 : 0);
    }

    // �������� ��������� ����� ��� �������� ����� �������
    public void LoadLampState()
    {
        isHoldingLamp = PlayerPrefs.GetInt("IsHoldingLamp", 0) == 1;
        isLightOn = PlayerPrefs.GetInt("IsLightOn", 0) == 1;

        // ��������������� ��������� �����
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
