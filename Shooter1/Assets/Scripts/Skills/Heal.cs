using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Sprite healSprite;
    public GameObject effect;
    public Player player;
    public float timeStamp = 0f;
    public float timeStamp2 = 0f;
    public float coolDown = 30f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Obiekt = GameObject.Find("Player");
        Player player = Obiekt.GetComponent<Player>();
        if (player.Heal_lvl1)
        {
            if (timeStamp + coolDown <= Time.time)
            {
                StartCoroutine(Flash());
                player.currentHp = player.currentHp + 1;
                timeStamp = Time.time;
            }
        }
    }

    IEnumerator Flash()
    {
        effect.GetComponent<SpriteRenderer>().sprite = healSprite;
        effect.GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("ejej");
        yield return new WaitForSeconds(0.3f);
        effect.GetComponent<SpriteRenderer>().enabled = false;
        StopAllCoroutines();
    }
}