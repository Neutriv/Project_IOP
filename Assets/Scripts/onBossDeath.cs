using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBossDeath : MonoBehaviour {
    public Player player;
    public int i;
    public GameObject win;
    public enemy en;
	// Use this for initialization
	void Start () {
       i = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<enemy>().currentHp == 0)
        {
            if (i == 0) {
                    Debug.Log("dieeeeeee boss");
            win.SetActive(true);
                    player.currentHp = 1000;
                    i++;
                }
        }
        
    }

    public IEnumerator Pause()
    {
        yield return new WaitForSecondsRealtime(1f);
        
    }
}
