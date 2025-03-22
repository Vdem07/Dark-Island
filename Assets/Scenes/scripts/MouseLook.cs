using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLoke : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1000.0f;
    [SerializeField] private Transform character;
    private float xRotation = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Tracking();
    }

    private void Tracking()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        // ������������ ������ ������ � ��������� ��� X (������������ ��������)
        transform.localRotation = Quaternion.Euler(xRotation, 1, 0);

        // ������������ �������� ������ ��� ������� ��� Y (�������������� ��������)
        character.Rotate(Vector3.up * mouseX);
    }
}

