using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immaterial_lvl2 : MonoBehaviour {

    public Sprite invSprite;
    public GameObject effect;
    public Player player;
    public float timeStamp = 0f;
    public float timeStamp2 = 0f;
    public float coolDown = 2f;
    public bool used = false;
    public bool invincibleRainbow;

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
                invincibleRainbow = true;
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
                    invincibleRainbow = false;
                    player.dmg = false;
                    player.speed = 0.1f;
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    used = false;
                }
            }
        }
        if (invincibleRainbow == true)
        {
            effect.GetComponent<SpriteRenderer>().sprite = invSprite;
            effect.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (invincibleRainbow == false)
        {
            effect.GetComponent<SpriteRenderer>().sprite = invSprite;
            effect.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
