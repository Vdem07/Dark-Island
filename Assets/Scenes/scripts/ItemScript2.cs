using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ItemScript2 : MonoBehaviour
{
    public static bool isPickedUp = false;
    private Transform holderToSmoke_pipe;
    private GameObject particles;
    private bool isParticles = false;
    [SerializeField] private AudioSource sound_of_zatyazhechka;
    [SerializeField] private float forseDrop;

    void Start()
    {
        // Найдем и сохраним трансформ руки персонажа
        holderToSmoke_pipe = transform.Find("smoking_pipe");
        particles = GameObject.Find("particle_smoke");
        particles.SetActive(false);
    }
    void Update()
    {
        if (isPickedUp)
        {

            transform.position = holderToSmoke_pipe.position;
            transform.rotation = holderToSmoke_pipe.rotation;

        }
    }

    public void PickUp(Transform holderTransform)
    {
        isPickedUp = true;
        holderToSmoke_pipe = holderTransform;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;

    }
    

    public void Drop()
    {
        isPickedUp = false;
        holderToSmoke_pipe = null;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().AddForce(Vector3.forward * forseDrop);

    }
    public void Smoking()
    {
        isParticles = !isParticles;
       
        if (particles != null && isParticles) {
            sound_of_zatyazhechka.Play();
            particles.gameObject.SetActive(true); 
        }
        else if (particles != null) { 
            sound_of_zatyazhechka.Stop(); 
            particles.gameObject.SetActive(false); }
    }
}