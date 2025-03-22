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
            // ������������ ��������� ���������� ��������
            playerController.enabled = !playerController.enabled;

        }
        private IEnumerator FadeInOutEffect()
        {
            // �������� ��������� Image
            if (imageMain == null)
            {
                Debug.LogError("Image component not found on the same GameObject as day1 script.");
                yield break;
            }

            // �������� ��������� ���� (������� �����-�����) �����������


            // ������������� ����� ��������� � �������� ���������� �����-������
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
            // ������������� ������������� ���� � ��������� ���������� �����-�������
            _uiText.color = new Color(1f, 1f, 1f, 0f);
            // ����� ������������ "���� 1" �������� ��������������� ����� � ����������� ���������
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
            // ���� ��������� ����� ����� ���������������� ����� � ������������ ���������
            yield return new WaitForSeconds(0.5f);

            // ���������� ��������
            subtitres1.SetActive(true);

            // ���� ���������� ��������������� �����
           
            yield return new WaitWhile(() => audioSource.isPlaying);

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
                subtitres1.SetActive(false);

                // �������� ������������ ��������
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

            // ���������� ������ � ������ �����
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
