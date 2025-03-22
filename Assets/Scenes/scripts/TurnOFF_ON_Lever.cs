using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnOFF_ON_Lever : MonoBehaviour
{
    public ItemType type;
    bool flag = false;
    public AudioSource onLever;
    public AudioSource offLever;
    [SerializeField] private GameObject LightOfLever;
    public ObjectRotation LightOfLeverMethodUpdate;
    public GameObject turnOnLeverComplited;
    public GameObject sleepToHome;
    public GameObject cut1;
    public float rotationSpeed;
    public Transform transformLever;
    private bool duringCut1 = false;
    public static bool ggg = true;
    public void InteractionLever()
    {
        if (type == ItemType.Lever && comedToMayak.ppp == false)
        {
            flag = !flag;
            if (flag)
            {
                Quaternion startRotation = Quaternion.Euler(-20f, 0f, 0f);
                Quaternion endRotation = Quaternion.Euler(-150f, 0f, 0f);
                float t = Time.deltaTime * rotationSpeed; // Используйте Time.deltaTime напрямую

                // Интерполируем кватернион между startRotation и endRotation
                Quaternion slerpedRotation = Quaternion.Slerp(startRotation, endRotation, t);

                // Применяем полученный кватернион к объекту
                transformLever.localRotation = slerpedRotation;
                ggg = false;
                Debug.Log(ggg);

                onLever.Play();
                turnOnLeverComplited.SetActive(true);
                
                if (duringCut1 == false) { 
                    CutsceneManager.Instance.StartCutscene("cut1"); 
                }
                else
                {
                   
                    duringCut1 = true;
                    sleepToHome.SetActive(true);
                }
                
                //cut1.SetActive(true);
                LightOfLever.SetActive(true);
               
                LightOfLeverMethodUpdate.FixedUpdate();
                
            }
            else
            {
                Quaternion startRotation2 = Quaternion.Euler(-150f, 0f, 0f);
                Quaternion endRotation2 = Quaternion.Euler(-20f, 0f, 0f);
                float t2 = Time.deltaTime * rotationSpeed; // Используйте Time.deltaTime напрямую

                // Интерполируем кватернион между startRotation и endRotation
                Quaternion slerpedRotation2 = Quaternion.Slerp(startRotation2, endRotation2, t2);

                // Применяем полученный кватернион к объекту
                transformLever.localRotation = slerpedRotation2;

                onLever.Stop();
                offLever.Play();
                LightOfLever.SetActive(false);
            }
           // GetComponentInParent<Animator>().SetBool("On", flag);
            //GetComponentInParent<Animator>().SetBool("Off", !flag);
        }
        if (type == ItemType.Test && comedToMayak.ppp == false)
        {
            Destroy(gameObject);
        }
    }
}
