using UnityEngine;
using UnityEngine.UI;

public class ToggleUIActivation : MonoBehaviour
{
    [SerializeField] private GameObject _uiObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiObject.SetActive(true);
        }
    }
}

