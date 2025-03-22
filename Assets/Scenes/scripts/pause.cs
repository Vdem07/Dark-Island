using UnityEngine;

public class pause: MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Используйте любую клавишу, которую вы хотите для паузы
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Устанавливаем масштаб времени в 0 для паузы
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1f; // Восстанавливаем нормальный масштаб времени
            Debug.Log("Game Resumed");
        }
    }
}
