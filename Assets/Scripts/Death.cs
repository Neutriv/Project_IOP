using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public GameObject sprite;
    public GameObject enemy;
    public GameObject ThisObject;
    public int HP;
    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = sprite.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        HP = enemy.GetComponent<enemy>().currentHp;
        if (HP <= 0)
        {
            
            StartCoroutine(Wait());
            
        }
	}

    IEnumerator Wait()
    {anim.SetBool("Death", true);
        yield return new WaitForSeconds(2f);
        Destroy(ThisObject);
        StopAllCoroutines();
    }
}
