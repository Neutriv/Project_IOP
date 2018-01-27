using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immaterial : MonoBehaviour {

    public Sprite invSprite;
    public GameObject effect;
    public Player player;
    public float timeStamp = 0f;
    public float timeStamp2 = 0f;
    public float coolDown = 2f;
    public bool used = false;

    public bool invincible;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject Obiekt = GameObject.Find("Player");
        Player player = Obiekt.GetComponent<Player>();
        if (player.Immaterial_lvl1)
        {
            if (Input.GetKey(KeyCode.E))
            {
                
                if (timeStamp + coolDown + 4f <= Time.time)
                {invincible = true;
                    player.dmg = false;
                    player.speed = 0.07f;
                    player.shooting_off = true;
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    used = true;
                    timeStamp = Time.time;

                }
            }
            if (used)
            {
                if (timeStamp + coolDown <= Time.time)
                {
                    invincible = false;
                    player.speed = 0.1f;
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    used = false;
                    player.shooting_off = false;
                }
            }

        }
        if (player.shooting_off == true)
        {
            effect.GetComponent<SpriteRenderer>().sprite = invSprite;
            effect.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (player.shooting_off == false)
        {
            effect.GetComponent<SpriteRenderer>().sprite = invSprite;
            effect.GetComponent<SpriteRenderer>().enabled = false;
        }

    }


    }
