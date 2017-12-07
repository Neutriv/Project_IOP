using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWeapons : MonoBehaviour {
    public Sprite nsprite;

    SpriteRenderer spriteR;
    Sprite[] sprites;

    // Use this for initialization
    void Start () {
        // spriteR = gameObject.GetComponent<SpriteRenderer>();
        //sprites = Resources.Load<Sprite>("Ammo_2");
        //sprites = Resources.Load("Ammo") as Sprite;
        sprites = Resources.LoadAll<Sprite>("Sprites");
        Debug.Log(sprites);          //Teraz zwraca null  
        Debug.Log(sprites.Length);   //Teraz zwraca 0
        CreateObjWeapon("Ammo_3", nsprite, new Vector3(-9, 1, -7));
       // CreateObjWeapon("Ammo_4", sprites, new Vector3(-9, 1, -8));       //Jak pobrać sprite z assetów?
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void CreateObjWeapon(System.String name, Sprite sprite, Vector3 pos)
    {

        GameObject objToSpawn = new GameObject(name);
        objToSpawn.AddComponent<BoxCollider>();
        objToSpawn.AddComponent<SpriteRenderer>();
        objToSpawn.GetComponent<SpriteRenderer>().sprite = sprite;
        objToSpawn.transform.parent = GameObject.Find("Weapons").transform;
        objToSpawn.transform.position = pos;
        objToSpawn.transform.rotation = new Quaternion(90, 0, 0, 90);
        objToSpawn.transform.localScale = new Vector3(5, 5, 5);
        objToSpawn.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
        objToSpawn.GetComponent<BoxCollider>().size = new Vector3(0.09f, 0.14f, 0.2f);

    }
}
