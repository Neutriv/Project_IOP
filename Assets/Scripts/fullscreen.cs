using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreen : MonoBehaviour {

    bool over;
    public Sprite fullScr;
    public Sprite fullScrOff;
    // Use this for initialization
    void Start()
    {
        if (Screen.fullScreen == true)
            gameObject.GetComponent<SpriteRenderer>().sprite = fullScr;
        if (Screen.fullScreen == false)
            gameObject.GetComponent<SpriteRenderer>().sprite = fullScrOff;

    }

    // Update is called once per frame
    void Update()
    {
        if (over)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //rozdzielczość
                Screen.fullScreen = !Screen.fullScreen;
            }
        }
    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        over = true;
        if (Screen.fullScreen == true)
            gameObject.GetComponent<SpriteRenderer>().sprite = fullScr;
        if (Screen.fullScreen == false)
            gameObject.GetComponent<SpriteRenderer>().sprite = fullScrOff;

    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        over = false;
        if (Screen.fullScreen == true)
            gameObject.GetComponent<SpriteRenderer>().sprite = fullScr;
        if (Screen.fullScreen == false)
            gameObject.GetComponent<SpriteRenderer>().sprite = fullScrOff;
    }
}
