using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectScript : MonoBehaviour
{
    public Transform FPSController;
    public Vector3 targetPosition;
    void Update()
    {
        // ���������� Vector3.Lerp ��� �������� ����������� ������� � ������� �������
        FPSController.position = targetPosition;

        // ���������, ������ �� ������ ������� ������� (����� ����� ������������ ����� ������ ��������)
        if (Vector3.Distance(FPSController.position, targetPosition) < 0.01f)
        {
            // ������ ������ ������� �������, ����� ��������� ������ ��������
            Debug.Log("Object reached target position!");
        }
        else { Debug.Log("������ ��� ���������"); }
    }
}