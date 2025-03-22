using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed; // �������� ��������

    public void FixedUpdate()
    {
        // �������� ������� ���� �������� �������
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // ��������� ����� ���� �������� ������ ��� Y
        float newRotationY = currentRotation.y + rotationSpeed * Time.deltaTime;

        // ������� ����� ������ �������� � ����������� ����� �������� ������ ��� Y
        Vector3 newRotation = new Vector3(currentRotation.x, newRotationY, currentRotation.z);

        // ��������� ����� ������ �������� � �������
        transform.rotation = Quaternion.Euler(newRotation);
    }
}
