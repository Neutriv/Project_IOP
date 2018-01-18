using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class addTp : MonoBehaviour {

    bool over;
    public GameObject skill;
    public string fileName;

    public StreamWriter sw;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + fileName))
        {
            content = reader.ReadToEnd();
        }
        if (content == "1")
            skill.GetComponent<SpriteRenderer>().color = new Color(60f, 60f, 60f, 255f);
        else
            skill.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 255f);

        if (over)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                content = string.Empty;
                using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "unspentpoints.txt"))
                {
                    content = reader.ReadToEnd();
                }
                int x = System.Int32.Parse(content);
                if (x > 0)
                {
                    content = string.Empty;
                    using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + fileName))
                    {
                        content = reader.ReadToEnd();
                    }
                    int y = System.Int32.Parse(content);
                    if (y == 0)
                    {
                        sw = new StreamWriter(Application.dataPath + "/data/" + fileName);
                        sw.Write("1");
                        sw.Close();
                        x = x - 1;
                        sw = new StreamWriter(Application.dataPath + "/data/" + "unspentpoints.txt");
                        sw.Write(x.ToString());
                        sw.Close();
                        content = string.Empty;
                        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "spentpoints.txt"))
                        {
                            content = reader.ReadToEnd();
                        }
                        x = System.Int32.Parse(content);
                        x = x + 1;
                        sw = new StreamWriter(Application.dataPath + "/data/" + "spentpoints.txt");
                        sw.Write(x.ToString());
                        sw.Close();
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
