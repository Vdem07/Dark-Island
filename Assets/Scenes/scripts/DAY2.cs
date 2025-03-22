using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class DAY2 : MonoBehaviour
    {
        [SerializeField] private Image imageMain;
        [SerializeField] private GameObject ImageMain;
        [SerializeField] private GameObject cursore;
        [SerializeField] private Text _uiText;
        [SerializeField] private GameObject _UiText;
        [SerializeField] private GameObject subtitresWhatIsIt;
        [SerializeField] private GameObject Sleeped;
        [SerializeField] private GameObject taskOsmotr;
        [SerializeField] private GameObject listOfTasks;
        [SerializeField] private GameObject tinOnBox;
        [SerializeField] private GameObject tinOnfloor;
        [SerializeField] private AudioSource _kamin;
        [SerializeField] private AudioSource _wind;
        public float fadeDuration;
        public float fadeDurationDay2;
        public AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        public AnimationCurve fadeCurveDay2 = AnimationCurve.EaseInOut(0, 0, 1, 1);
        public AudioClip[] audioClips;
        private AudioSource audioSource;
        private int currentClipIndex = 0;
        public static bool tin = true;
        [SerializeField] private GameObject night_to_day;
        [SerializeField] private GameObject day_to_night;
        public  DayCycleManager_Day2 dayCycleManager2 = new DayCycleManager_Day2();
        public  DayCycleManager dayCycleManager = new DayCycleManager();
        public FirstPersonController playerController;
        private void ToggleMovement()
        {
            // ������������ ��������� ���������� ��������
            playerController.enabled = !playerController.enabled;

        }
        public void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Player") && TurnOFF_ON_Lever.ggg == false)
            {
                DisEnableCursor();
                ToggleMovement();
                night_to_day.SetActive(false);
                day_to_night.SetActive(true);
                dayCycleManager2.Sun.intensity = 1.0f;
                dayCycleManager.Sun.intensity = 1.0f;
                playerController.SetMenuState(true);
                ImageMain.SetActive(true);
                _kamin.Stop();
                _wind.Stop();
                _UiText.SetActive(true);
                // �������� ��������� AudioSource �� �������� �������
                audioSource = GetComponent<AudioSource>();
                cursore.SetActive(false);
                tinOnBox.SetActive(false);
                TurnOFF_ON_Lever.ggg = true;
                tin = false;



                StartCoroutine(FadeInOutEffect());
            }
        }

        private IEnumerator FadeInOutEffect()
        {
            // �������� ��������� Image
            if (imageMain == null)
            {
                Debug.LogError("Image component not found on the same GameObject as DAY2 script.");
                yield break;
            }

            // �������� ��������� ���� (������� �����-�����) �����������



            bool isTextEnabled = true;
            if (isTextEnabled) { _uiText.enabled = true; } else { Debug.Log("����� �� ����������"); }
            float currentTime = 0f;
            while (currentTime < fadeDurationDay2)
            {
                float t2 = currentTime / fadeDurationDay2;
                float lerpedAlpha = Mathf.Lerp(0f, 1f, t2);

                _uiText.color = Color.Lerp(Color.white, new Color(1f, 1f, 1f, 0f), t2);

                currentTime += Time.deltaTime;

                yield return null;
            }
            // ������������� ������������� ���� � ��������� ���������� �����-�������
            _uiText.color = new Color(1f, 1f, 1f, 0f);
            // ����� ������������ "���� 2" �������� ��������������� ����� � ����������� ���������
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
        IEnumerator DisEnableCursor()
        {
            yield return new WaitForEndOfFrame();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        }
        private IEnumerator DisplaySubtitles()
        {


            // ���� ���������� ��������������� �����
            yield return new WaitWhile(() => audioSource.isPlaying);

            // ���� ��������� ����� ����� ���������������� ����� � ������������ ���������
            yield return new WaitForSeconds(0.2f);

            // ���������� ��������
            subtitresWhatIsIt.SetActive(true);

            // ����������� ������ ��� ���������� ����� � ��������
            currentClipIndex++;

            // ���� ���� ��� �����, ���������� ����
            if (currentClipIndex < audioClips.Length)
            {
                PlayAudioWithSubtitle();
            }
            else
            {
                // ����� ��������� ���� ������, �������� ��������
                subtitresWhatIsIt.SetActive(false);

                // �������� ������������ ��������
                StartCoroutine(FadeOutImage());
            }
        }

        private IEnumerator FadeOutImage()
        {

            bool isImageEnabled = true;
            if (isImageEnabled) { imageMain.enabled = true; } else { Debug.Log("����������� �� �����������"); }
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
            ToggleMovement();
            playerController.SetMenuState(false);
            Sleeped.SetActive(true);
            ImageMain.SetActive(false);
            _UiText.SetActive(false);
            tinOnfloor.SetActive(true);
            cursore.SetActive(true);
            taskOsmotr.SetActive(true);
            listOfTasks.SetActive(true);
            _kamin.Play();
            _wind.Play();
        }
    }
}