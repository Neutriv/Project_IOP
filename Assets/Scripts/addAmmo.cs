using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addAmmo : MonoBehaviour {
    public int amount;
    

    // Use this for initialization
    void Start ()
    {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject Player = GameObject.Find("Player");
            Player player = Player.GetComponent<Player>();
            player.numberOfBullets += amount;
            Destroy(gameObject);

          }


    }
}
