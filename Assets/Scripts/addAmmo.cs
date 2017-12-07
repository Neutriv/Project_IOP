using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addAmmo : MonoBehaviour {
    public int amount;
    public Player player;
        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.bron.addAmmo(amount);
            Destroy(gameObject);

          }


    }
}
