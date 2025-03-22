using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class day1 : MonoBehaviour
    {
        [SerializeField] private Image imageMain;
        [SerializeField] private GameObject ImageMain;
        [SerializeField] private GameObject cursore;
        [SerializeField] private Text _uiText;
        [SerializeField] private GameObject subtitres1;
        [SerializeField] private GameObject task1;
        [SerializeField] private GameObject listOfTasks;
       // [SerializeField] private GameObject ogranichitel;
        [SerializeField] private GameObject backWind;
        public FirstPersonController playerController;
        public float fadeDuration;
        public float fadeDurationDay1;
        public AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        public AnimationCurve fadeCurveDay1 = AnimationCurve.EaseInOut(0, 0, 1, 1);
        public AudioClip[] audioClips;
        private AudioSource audioSource;

        private int currentClipIndex = 0;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            
            ToggleMovement();
            StartCoroutine(DisEnableCursor());
            StartCoroutine(FadeInOutEffect());
        }

        private void ToggleMovement()
        {
            // Инвертируйте состояние блокировки движения
            playerController.enabled = !playerController.enabled;

        }
        private IEnumerator FadeInOutEffect()
        {
            // Получаем компонент Image
            if (imageMain == null)
            {
                Debug.LogError("Image component not found on the same GameObject as day1 script.");
                yield break;
            }

            // Получаем начальный цвет (включая альфа-канал) изображения


            // Интерполируем между начальным и конечным значениями альфа-канала
            float currentTime = 0f;
            while (currentTime < fadeDurationDay1)
            {
                float t2 = currentTime / fadeDurationDay1;
                float lerpedAlpha = Mathf.Lerp(0f, 1f, t2);

                _uiText.color = Color.Lerp(Color.white, new Color(1f, 1f, 1f, 0f), t2);

                currentTime += Time.deltaTime;
                ///

                yield return null;
            }
            // Устанавливаем окончательный цвет с полностью прозрачным альфа-каналом
            _uiText.color = new Color(1f, 1f, 1f, 0f);
            // После исчезновения "ДЕНЬ 1" начинаем воспроизведение звука и отображение субтитров
            PlayAudioWithSubtitle();
        }

        private void PlayAudioWithSubtitle()
        {
            if (currentClipIndex < audioClips.Length)
            {
                audioSource.clip = audioClips[currentClipIndex];
                audioSource.Play();

                StartCoroutine(DisplaySubtitles());
            }
        }

        private IEnumerator DisplaySubtitles()
        {
            // Ждем некоторое время перед воспроизведением аудио и отображением субтитров
            yield return new WaitForSeconds(0.5f);

            // Отображаем субтитры
            subtitres1.SetActive(true);

            // Ждем завершения воспроизведения аудио
           
            yield return new WaitWhile(() => audioSource.isPlaying);

            // Увеличиваем индекс для следующего звука и субтитра
            currentClipIndex++;

            // Если есть еще аудио, продолжаем цикл
            if (currentClipIndex < audioClips.Length)
            {
                PlayAudioWithSubtitle();
            }
            else
            {
                // После окончания всех звуков, исчезаем субтитры
                subtitres1.SetActive(false);

                // Начинаем исчезновение картинки
                StartCoroutine(FadeOutImage());
            }
        }
        IEnumerator DisEnableCursor()
        {
            yield return new WaitForEndOfFrame();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            
        }
        private IEnumerator FadeOutImage()
        {
            Color startColor = imageMain.color;
            float currentTime = 0f;
            while (currentTime < fadeDuration)
            {
                float t = currentTime / fadeDuration;
                float t1 = fadeCurve.Evaluate(t);
                float lerpedAlpha = Mathf.Lerp(startColor.a, 0f, t1);

                imageMain.color = new Color(startColor.r, startColor.g, startColor.b, lerpedAlpha);

                currentTime += Time.deltaTime;
                yield return null;
            }
            imageMain.color = new Color(startColor.r, startColor.g, startColor.b, 0.0f);

            // Отображаем курсор и список задач
            ImageMain.SetActive(false);
            cursore.SetActive(true);
            task1.SetActive(true);
            listOfTasks.SetActive(true);
            //ogranichitel.SetActive(false);
            ToggleMovement();
            playerController.SetMenuState(false);
            backWind.SetActive(true);
            playerController.SetMenuState(false);
        }
    }
}
