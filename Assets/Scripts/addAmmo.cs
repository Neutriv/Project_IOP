using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addAmmo : MonoBehaviour {
    public int amount;
    public Player player;

    private void Update()
    {
        if (player.isAmmo)
        {
            player.numberOfBullets += 10;
            Destroy(gameObject);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.numberOfBullets += 10;
            Destroy(gameObject);

          }


    }
}
