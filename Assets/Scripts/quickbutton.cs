using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class quickbutton : MonoBehaviour
{

    bool over;
    public Sprite locked,lit,unlit;
    public bool quickPlayLocked = true;
    StreamWriter sw;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if (quickPlayLocked)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = locked;
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            if (over)
                gameObject.GetComponent<SpriteRenderer>().sprite = lit;
            if (!over)
                gameObject.GetComponent<SpriteRenderer>().sprite = unlit;

            gameObject.GetComponent<Collider>().enabled = true;
        }
        string content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "quickplayenabled.txt"))
        {
            content = reader.ReadToEnd();
        }
        if (content == "0")
            quickPlayLocked = true;
        else
            quickPlayLocked = false;
       
        if (over)
        {
            if (!quickPlayLocked)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    sw = new StreamWriter(Application.dataPath + "/data/" + "gamemode.txt");
                    sw.Write("2");
                    sw.Close();
                }
            }
        }
    }
    void OnMouseOver()
{
    //If your mouse hovers over the GameObject with the script attached, output this message
    over = true;
    if (quickPlayLocked)
        gameObject.GetComponent<SpriteRenderer>().sprite = locked;
    else
            gameObject.GetComponent<SpriteRenderer>().sprite = lit;

    }
void OnMouseExit()
{
    //The mouse is no longer hovering over the GameObject so output this message each frame
    over = false;
    if (quickPlayLocked)
        gameObject.GetComponent<SpriteRenderer>().sprite = locked;
    else
            gameObject.GetComponent<SpriteRenderer>().sprite = unlit;
    }
}
