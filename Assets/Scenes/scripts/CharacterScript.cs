using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public Transform handAttachmentPoint;
    public Transform lampOrientationPoint;
    public GameObject heldItem;
    public Transform cameraTransform;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem == null)
            {
                // Поиск ближайшего предмета, который можно поднять.
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
                foreach (Collider collider in hitColliders)
                {
                    ItemScript item = collider.GetComponent<ItemScript>();
                    if (item != null)
                    {
                     
                        item.PickUp(handAttachmentPoint);
                        heldItem = item.gameObject;
                        //heldItem.transform.LookAt(cameraTransform);
                        //float cameraRotationAngle = Quaternion.Angle(lampOrientationPoint.rotation, cameraTransform.rotation);

                        // Поворачиваем руку относительно камеры на угол cameraRotationAngle
                        //transform.rotation = Quaternion.Euler(0, 0, 0);
                        Vector3 lookDirection = lampOrientationPoint.position - transform.position;
                        lookDirection.z = 0f; // Ограничиваем вертикальное вращение.
                        heldItem.transform.LookAt(lookDirection);
                        Quaternion cameraRotation = cameraTransform.rotation;
                        transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up) * cameraRotation;
                        break;
                    }
                    
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (heldItem != null)
            {
                // Бросьте предмет.
                ItemScript item = heldItem.GetComponent<ItemScript>();
                item.Drop();
                heldItem = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (heldItem != null)
            {
                ItemScript item = heldItem.GetComponent<ItemScript>();
                item.OnLighting();
            }
        }
    }
}

