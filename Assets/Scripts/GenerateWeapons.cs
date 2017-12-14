using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWeapons : MonoBehaviour {
    public Player player;
    //public Sprite nsprite;

    SpriteRenderer spriteR;
    public Sprite[] sprites;
    weapons weapon;
    
    // Use this for initialization
    void Start () {
        rangedWeapons rW = new rangedWeapons(player.nbullet, player.ngun);
        Weapon1 w1=new Weapon1(player.nbullet, player.ngun); 
        Weapon2 w2=new Weapon2(player.nbullet, player.ngun); 
        rW.create("Ammo_1", rW, new Vector3(-9, 1, -7));
        w1.create("Ammo_2", w1, new Vector3(-9, 1, -8));
        w2.create("Ammo_3", w2, new Vector3(-9, 1, -9));


    }
	
	// Update is called once per frame
	void Update () {
		
	}
   
}
