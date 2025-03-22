using UnityEngine;

public class pause: MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // ����������� ����� �������, ������� �� ������ ��� �����
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // ������������� ������� ������� � 0 ��� �����
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1f; // ��������������� ���������� ������� �������
            Debug.Log("Game Resumed");
        }
    }
}
