using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeInscrection_DoorOpen : MonoBehaviour
{
    [SerializeField] private GameObject _CheckedHome;
    [SerializeField] private GameObject _checkSaray;
    [SerializeField] private GameObject _secondSub;
    [SerializeField] private AudioSource _sub_fet2;
    [SerializeField] private GameObject doorInSaray;
    private bool noMoreEnter = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !noMoreEnter)
        {
            noMoreEnter = true;
            _CheckedHome.SetActive(true);
            _secondSub.SetActive(true);
            _sub_fet2.Play();
            
            StartCoroutine(StopDisplaySubtitles());
        }
    }
    public IEnumerator StopDisplaySubtitles()
    {
        yield return new WaitForSeconds(6.5f);
        _sub_fet2.Stop();
        _checkSaray.SetActive(true);
        _secondSub.SetActive(false);
        Quaternion targetRotation = Quaternion.Euler(0, -100.0f, 0);
        doorInSaray.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime);
        StopDoorScript();
    }
    public void StopDoorScript()
    {
        // Получаем компонент doorInSaray на текущем объекте
        doorInSaray doorInSaray = GetComponentInChildren<doorInSaray>();

        // Проверяем, найден ли компонент doorInSaray
        if (doorInSaray != null)
        {
            doorInSaray.messageText = null;
            doorInSaray.DoorOpenSound1 = null;
        }
        else
        {
           // Debug.LogWarning("Компонент doorInSaray не найден на текущем объекте");
            Debug.LogWarning("Компонент InteractScript не найден на текущем объекте");
        }
    }
}
