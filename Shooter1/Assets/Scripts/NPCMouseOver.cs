using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMouseOver : MonoBehaviour {


    public Player Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        Player.canShoot = false;
    }

    void OnMouseExit()
    {
        Player.canShoot = true;
    }
}
