using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private float interactDistance6 = 6.0f;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, interactDistance6, 1 << LayerMask.NameToLayer("pipe")))
            { return; }
            else if (Physics.Raycast(ray, out hit, interactDistance6))
            { 
            if (hit.collider.CompareTag("Door"))
            {
               hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
            }
            if (hit.collider.CompareTag("DoorInSaray"))
            {
                hit.collider.transform.parent.GetComponent<doorInSaray>().ChangeDoorState();
            }
            if (hit.collider.CompareTag("yazhic") && hit.collider.CompareTag("pipe") == false)
            {
                hit.collider.transform.GetComponent<openTumbochka>().Interaction();
            }
            if (hit.collider.CompareTag("Lever"))
            {
                hit.collider.transform.GetComponent<TurnOFF_ON_Lever>().InteractionLever();
            }
            if (hit.collider.CompareTag("balalayka"))
            {
                hit.collider.GetComponent<balalayka>().PlayBalalayka();
            }
            }
        }
    }
}


