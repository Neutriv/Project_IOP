using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWeapons : MonoBehaviour {
    public Player player;
    //public Sprite nsprite;

    SpriteRenderer spriteR;
    public Sprite[] sprites;
    public weapons[] generatedWeapons;


    public GameObject[] miejsca;
    // Use this for initialization
    void Start () {
        rangedWeapons rW = new rangedWeapons();
        Weapon1 w1=new Weapon1(); 
        Weapon2 w2=new Weapon2();
        generatedWeapons = new weapons[] { rW, w1, w2};
        rW.create("Ammo_1", rW, miejsca[0].GetComponent<Transform>().position);
        w1.create("Ammo_2", w1, miejsca[1].GetComponent<Transform>().position);
        w2.create("Ammo_3", w2, miejsca[2].GetComponent<Transform>().position);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
   
}
