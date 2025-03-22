using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed; // Скорость вращения

    public void FixedUpdate()
    {
        // Получаем текущий угол поворота объекта
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Вычисляем новый угол поворота вокруг оси Y
        float newRotationY = currentRotation.y + rotationSpeed * Time.deltaTime;

        // Создаем новый вектор поворота с обновленным углом поворота вокруг оси Y
        Vector3 newRotation = new Vector3(currentRotation.x, newRotationY, currentRotation.z);

        // Применяем новый вектор поворота к объекту
        transform.rotation = Quaternion.Euler(newRotation);
    }
}
