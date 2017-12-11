using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwap : MonoBehaviour
{
    public Player player;
    public GameObject nbullet;
    public GameObject ngun;
    public Sprite nsprite;

    public bool swap = false;
    public Sprite curr;
    private GameObject that;
    int ammo;
    weapons weapon;
    GameObject weaponsOnFloor;
    Sprite sprite;
    // Use this for initialization
    void Start()
    {
        nbullet = player.nbullet;   //inny rodzaj amunicji?
        ngun = player.ngun;
        nsprite = GetComponent<SpriteRenderer>().sprite;
        weapon  = new Weapon1(nbullet, ngun, nsprite);
    
    }

    // Update is called once per frame
    void Update()
    {
        if (swap)               
        {
            if (Input.GetKeyDown(KeyCode.E))
            {                              
                player.bron.weaponSwap(player.bron, weapon);        //zamiana logiczna
                GameObject Ammo_0 = GameObject.Find("Ammo_0");                                                      
                GameObject Ammo_1 = that;                                                                           
                Ammo_1.GetComponent<SpriteRenderer>().sprite = Ammo_0.GetComponent<SpriteRenderer>().sprite;            //zamiana grafiki broni 
                player.bron.equip();
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
}
