using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_lvl2 : MonoBehaviour {

    public Player player;
    public float timeStamp = 0f;
    public float timeStamp2 = 0f;
    public float coolDown = 20f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject Obiekt = GameObject.Find("Player");
        Player player = Obiekt.GetComponent<Player>();
        if (player.Heal_lvl2)
        {
            if (timeStamp + coolDown <= Time.time)
            {
                player.currentHp = player.currentHp + 1;
                timeStamp = Time.time;
            }
        }
    }
}
