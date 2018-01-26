using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class characterSelection : MonoBehaviour {

    bool over;
    public bool select = false;
    public Sprite selected;
    public Sprite notSelected;
    public characterSelection char2, char3;
    public string namee;
    public StreamWriter sw;
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
                //zmiana wartości pliku currentskin
                if (namee == "0")
                {
                    
                    PlayerPrefs.SetInt("currentskin", 0);

                    select = true;
                    char2.select = false;
                    char3.select = false;
                }
                if (namee == "1")
                {
                    //tutaj sprawdzić czy można wybrać jeśli tak to dalej
                    //currentChar.text = "1";
                    string content = PlayerPrefs.GetInt("redenabled", 0).ToString();
                    if (content == "1")
                    {
                        PlayerPrefs.SetInt("currentskin", 1);
                        select = true;
                        char2.select = false;
                        char3.select = false;
                    }


                }
                if (namee == "2")
                {//titaj sprawdzić czy można wybrać
                    //currentChar.text = "2";
                    string content = PlayerPrefs.GetInt("goldenabled",0).ToString();
                    if (content == "1")
                    {
                        PlayerPrefs.SetInt("currentskin", 2);

                        select = true;
                        char2.select = false;
                        char3.select = false;
                    }
                }

            }
            
        }
        if (select)
                gameObject.GetComponent<SpriteRenderer>().sprite = selected;
            if(!select)
                gameObject.GetComponent<SpriteRenderer>().sprite = notSelected;
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
