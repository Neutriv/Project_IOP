using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class startGamebutton : MonoBehaviour {

    bool over;
    StreamWriter sw;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (over)
        {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    sw = new StreamWriter(Application.dataPath + "/data/" + "gamemode.txt");
                    sw.Write("2");
                    sw.Close();
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
