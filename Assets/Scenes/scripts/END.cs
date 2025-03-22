using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class END : MonoBehaviour
    {
        public static bool GameIsPaused = false;
        public GameObject pauseMenuUI;
        [SerializeField] private GameObject _windSound;
        [SerializeField] private GameObject _caminSound;
        [SerializeField] private GameObject _cursore;
        public FirstPersonController playerController;


        void Start()
        {
            Pause();
        }

        public void Pause()
        {
            StartCoroutine(EnableCursor());
            playerController.SetMenuState(true);
            pauseMenuUI.SetActive(true);
            _windSound.SetActive(false);
            _caminSound.SetActive(false);
            _cursore.SetActive(false);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        public void LoadMenu()
        {
            Debug.Log("LoadMenu");
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1.0f;
            GameIsPaused = false;
            SceneManager.LoadScene("Menu");

            StartCoroutine(EnableCursor());
        }

        IEnumerator EnableCursor()
        {
            yield return new WaitForEndOfFrame();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
