using System.Net.NetworkInformation;
using UnityEngine;

public class CharacterScript2 : MonoBehaviour
{
    public Transform smoking_pipeAttachmentPoint;
    public Transform smoking_pipeOrientationPoint;
    public GameObject heldItem;
    public Transform cameraTransform;
    InteractScript interactScript  = new InteractScript();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem == null)
            {
                Vector3 screenCenter = new(Screen.width / 2f, Screen.height / 2f, 0f);
                Ray ray1 = Camera.main.ScreenPointToRay(screenCenter);
                RaycastHit hit;
                
                if (Physics.Raycast(ray1, out hit, 6.0f, 1 << LayerMask.NameToLayer("ящик")))
                {
                    Debug.DrawRay(ray1.origin, ray1.direction * hit.distance, Color.white);
                    interactScript.Update();
                }
                else if (Physics.Raycast(ray1, out hit, 6.0f, 1 << 7))
                { 
                    if (hit.collider.CompareTag("pipe"))
                    {
                        Debug.DrawRay(ray1.origin, ray1.direction * hit.distance, Color.red);
                        ItemScript2 item = hit.collider.GetComponent<ItemScript2>();
                        if (item != null)
                        {
                            item.PickUp(smoking_pipeAttachmentPoint);
                            heldItem = item.gameObject;
                        }
                    }
                  } 
                
                }
            }
        
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (heldItem != null)
            {
                // Ѕросьте предмет.
                ItemScript2 item = heldItem.GetComponent<ItemScript2>();
                item.Drop();
                heldItem = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (heldItem != null)
            {
                ItemScript2 item = heldItem.GetComponent<ItemScript2>();
                item.Smoking();
            }
        }
    }
}
