using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwap : MonoBehaviour
{
    public bool swap = false;
    public Sprite current;
    private GameObject that;
    public int ammoAmount = 10;
    int ammo;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (swap)               //UWAGA!!! zamiana broni zmienia tylko wygląd, cała reszta pozostaje bez zmian, trzeba dorobić dziedziczenie
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject Ammo_0 = GameObject.Find("Ammo_0");                                                      //jaka jest aktualna broń
                GameObject Ammo_1 = that;                                                                           //broń na ziemi
                current = Ammo_0.GetComponent<SpriteRenderer>().sprite;                                             //jaki ma wygląd aktualna broń
                Ammo_0.GetComponent<SpriteRenderer>().sprite = Ammo_1.GetComponent<SpriteRenderer>().sprite;        //zamiana broni
                Ammo_1.GetComponent<SpriteRenderer>().sprite = current;                                             //zostawienie broni na ziemi


                GameObject Player = GameObject.Find("Player");
                Player player = Player.GetComponent<Player>();                                                      // Do przerobienia, system amunicji
                ammo = player.numberOfBullets;
                player.numberOfBullets = ammoAmount;
                ammoAmount = ammo;

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
