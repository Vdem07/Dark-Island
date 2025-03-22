using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ggg : MonoBehaviour
{
    private GameObject currentLamp; // ������� �����, �������� ����������
    private Transform hand; // ��������� ���� ���������
    public Transform lampOrientationPoint;
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

    }

    void PickUpLamp()
    {
        if (currentLamp == null)
        {
            // ������� ����� � ����� (�� �����, ���� ��� ������� ������� �������������) � ��������� �� ������� ������.
            currentLamp = GameObject.Find("oil_lamp"); // ����� "Lamp" - ��� ��� ������� ����� � �����.

            if (currentLamp != null)
            {
                // ��������� �����, ����� "HandPosition" �� ���������
                currentLamp.transform.parent = transform.Find("HandPosition");

                // ���������� ���� � ��������� ������ �� �����
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
            // ��������� ���� � �������� ������ �� �����
            hand.gameObject.SetActive(false);
            isHoldingLamp = false;
            currentLamp.GetComponent<Rigidbody>().isKinematic = false;

            // ������� ����� ������
            currentLamp.GetComponent<Rigidbody>().AddForce(hand.forward * 5f, ForceMode.Impulse);

            // ������� ������ �� ������� �����
            currentLamp = null;
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

    }
}
