using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool open = false;
    public float DoorOpenAngle = 0f;
    public float DoorCloseAngle = 0f;
    public AudioClip DoorOpenSound;
    public void ChangeDoorState()
    {
        open = !open;
        gameObject.GetComponent<AudioSource>().PlayOneShot(DoorOpenSound);
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, DoorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation,targetRotation, Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, DoorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, Time.deltaTime);
        }
    }
}
