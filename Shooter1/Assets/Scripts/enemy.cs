using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public int maxHp;
    public int currentHp;
    public bool isD;
    public bool canBeDamaged = true;
    // Use this for initialization
    void Start () {
        currentHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
        if (isD == true)
                {
            if (canBeDamaged == true)
            {
                StartCoroutine(Wait());
            }
                }

        if (currentHp <= 0)
        {

            //Destroy(GameObject.FindWithTag("AI"));

        }
    }

    
IEnumerator Wait()
{
            Debug.Log("EnemyDemage!");
            isD = false;
            currentHp--;
            canBeDamaged = false;
            yield return new WaitForSeconds(0.4f);

            canBeDamaged = true;
            StopAllCoroutines();
}
void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerProjectile"))
        {
            if (isD != true)
                isD = true;
            
        }


    }
}
