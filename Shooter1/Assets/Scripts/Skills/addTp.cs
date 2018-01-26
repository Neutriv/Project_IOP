using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;

public class addTp : MonoBehaviour {

    bool canAdd = true;
    bool over;
    public GameObject skill;
    public string fileName;

    //public StreamWriter sw;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (fileName == "teleport")
                {
                    if (PlayerPrefs.GetInt("dash", 0) == 0)
                        canAdd = false;
                }
            if (fileName == "immaterial2")
                {
                    if (PlayerPrefs.GetInt("immaterial", 0) == 0)
                        canAdd = false;
                }
            if (fileName == "heal2")
                {
                    if (PlayerPrefs.GetInt("heal1", 0) == 0)
                        canAdd = false;
                }

        string content = PlayerPrefs.GetInt(fileName, 0).ToString();
        if (content == "1")
            skill.GetComponent<SpriteRenderer>().color = new Color(60f, 60f, 60f, 255f);
        else
            skill.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 255f);

        if (over)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               
                if (canAdd)
                {
                    int x = PlayerPrefs.GetInt("unspentpoints", 0);
                    if (x > 0)
                    {
                        if (PlayerPrefs.GetInt(fileName, 0) == 0)
                        {

                            PlayerPrefs.SetInt(fileName, 1);
                            x = x - 1;
                            PlayerPrefs.SetInt("unspentpoints", x);
                        }
                    }
                }

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
