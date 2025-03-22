using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectScript : MonoBehaviour
{
    public Transform FPSController;
    public Vector3 targetPosition;
    void Update()
    {
        // Используем Vector3.Lerp для плавного перемещения объекта к целевой позиции
        FPSController.position = targetPosition;

        // Проверяем, достиг ли объект целевой позиции (можно также использовать более точную проверку)
        if (Vector3.Distance(FPSController.position, targetPosition) < 0.01f)
        {
            // Объект достиг целевой позиции, можно выполнить нужные действия
            Debug.Log("Object reached target position!");
        }
        else { Debug.Log("Ошибка при телепорте"); }
    }
}