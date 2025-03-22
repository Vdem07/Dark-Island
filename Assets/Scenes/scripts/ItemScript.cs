using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public static bool isPickedUp = false;
    private Transform holder;
    private Transform point;
    public Transform smoke_pipe;
    //public Light pointLight;
    private bool isLightOn = false;
    private Transform hand; // Трансформ руки персонажа

    void Start()
    {
        // Найдем и сохраним трансформ руки персонажа
        hand = transform.Find("hand");
        point = transform.Find("Point");
        smoke_pipe = transform.Find("smoke_pipe");

        // Спрячем руку при старте
        hand.gameObject.SetActive(false);
        point.gameObject.SetActive(false);
    }
    void Update()
    {
        if (isPickedUp)
        {
            
            transform.position = holder.position;
            transform.rotation = holder.rotation;

        }
    }

    public void PickUp(Transform holderTransform)
    {
        isPickedUp = true;
        holder = holderTransform;
        hand.gameObject.SetActive(true);
        GetComponent<Rigidbody>().isKinematic = true;
        
    }
    public void OnLighting()
    {

            isLightOn = !isLightOn;

        if (point != null && isLightOn) { point.gameObject.SetActive(true);}
        else if (point != null) {point.gameObject.SetActive(false); }
    }

    public void Drop()
    {
        isPickedUp = false;
        holder = null;
        hand.gameObject.SetActive(false);
        GetComponent<Rigidbody>().isKinematic = false;
       
    }
}