using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class menuUnspentPoints : MonoBehaviour
{

    StreamWriter sw;
    public Sprite zero, jeden, dwa, trzy, cztery, piec, szesc;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "unspentpoints.txt"))
        {
            content = reader.ReadToEnd();
        }
        if (content == "0")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = zero;
        }
        if (content == "1")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = jeden;
        }
        if (content == "2")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = dwa;
        }
        if (content == "3")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = trzy;
        }
        if (content == "4")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = cztery;
        }
        if (content == "5")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = piec;
        }
        if (content == "6")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = szesc;
        }
    }
}
