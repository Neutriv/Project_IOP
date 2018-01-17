﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immaterial_lvl2 : MonoBehaviour {

    public Player player;
    public float timeStamp = 0f;
    public float timeStamp2 = 0f;
    public float coolDown = 2f;
    public bool used = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GameObject Obiekt = GameObject.Find("Player");
        Player player = Obiekt.GetComponent<Player>();
        if (player.Immaterial_lvl2)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (timeStamp + coolDown + 4f <= Time.time)
                {
                    player.speed = 0.07f;
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    used = true;
                    timeStamp = Time.time;

                }
            }
            if (used)
            {
                if (timeStamp + coolDown <= Time.time)
                {
                    player.speed = 0.1f;
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    used = false;
                }
            }
        }

    }
}
