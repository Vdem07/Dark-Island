using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Lever,
    Box,
    Test
}


public class openTumbochka : MonoBehaviour {
    public ItemType type;
    bool flag = false;
    public AudioSource openComod;
    public AudioSource closeComod;
    public void Interaction()
    {
        if (type == ItemType.Box)
        {
            flag = !flag;
            if (flag)
            {
                openComod.Play();
            }else
            {
                openComod.Stop();
                closeComod.Play();
            }
            GetComponentInParent<Animator>().SetBool("open", flag);
            GetComponentInParent<Animator>().SetBool("close", !flag);
        }
        if (type == ItemType.Test)
        {
            Destroy(gameObject);
        }
    }

    
}

