using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onBossDeath : MonoBehaviour {

    public GameObject win;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<enemy>().currentHp == 0)
        {
            win.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
	}
}
