﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wstepbutton : MonoBehaviour {
    bool over;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(over)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                SceneManager.LoadScene("poziom1", LoadSceneMode.Single);
            }
        }
	}
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        over = true;

    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        over = false;
    }
}
