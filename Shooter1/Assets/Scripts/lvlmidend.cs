using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlmidend : MonoBehaviour {
    public string levelname;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))
        {
            Debug.Log("level end");
            SceneManager.LoadScene(levelname, LoadSceneMode.Single);
        }
    }
}
