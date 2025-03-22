using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class Pause_menu : MonoBehaviour
    {
        public static bool GameIsPaused = false;
        public GameObject pauseMenuUI;
        [SerializeField] private AudioSource _windSound;
        [SerializeField] private AudioSource _caminSound;
        [SerializeField] private GameObject _cursore;
        public FirstPersonController playerController;

      
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        public void Resume()
        {
            playerController.SetMenuState(false);
            pauseMenuUI.SetActive(false);
            if (KaminAndWindSoundOnOFF.inHome == true)
            {
                _caminSound.Play();
                _caminSound.volume = 0.1f;
                _windSound.Play();
                _windSound.volume = 0.01f;
            }
            else
            {
                _windSound.Play();
                _windSound.volume = 0.05f;
                _caminSound.Stop();
            }
           
            _cursore.SetActive(true);
            Time.timeScale = 1.0f;
            GameIsPaused = false;
        }
        public void Pause()
        {
            StartCoroutine(EnableCursor());
            playerController.SetMenuState(true);
            pauseMenuUI.SetActive(true);
            _caminSound.Stop();
            _windSound.Stop();
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
            SceneManager.LoadScene(0);

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
