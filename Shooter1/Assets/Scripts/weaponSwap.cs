using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwap : MonoBehaviour
{
    public Player player;

    public System.Type classType;
    public bool swap = false;
    private GameObject that;
    // Use this for initialization
    void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    {
        if (swap)               
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.bron = System.Activator.CreateInstance(classType) as weapons;
                player.bron.equip(that);
            }
        }
    }

   

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            that = gameObject;              //jaka broń leży
            swap = true;                    //pozwala podnieść broń

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            that = null;                //lekkie zabezpieczenie
            swap = false;

        }
    }
    void swapWeapon(weapons w1, weapons w2)
    {
        weapons w = w1;
        w1 = w2;
        w2 = w;
    }

}
