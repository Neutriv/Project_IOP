using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class emterMenu : MonoBehaviour {
    public int i = 0;
    public Transform destination;
    public float speed = 2.0f;
    public GameObject camera;
    StreamWriter sw;
	// Use this for initialization
	void Start () {
        string content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "exp.txt"))
        {
            content = reader.ReadToEnd();
        }
        int x = System.Convert.ToInt32(content);
        sw = new StreamWriter(Application.dataPath + "/data/" + "currentlvl.txt");
        if(x<16)
            sw.Write("0");
        else if(16<x && x<30)
            sw.Write("1");
        else if (30 < x && x < 45)
            sw.Write("2");
        else if (45 < x && x < 60)
            sw.Write("3");
        else if (60 < x && x < 75)
            sw.Write("4");
        else if (75 < x && x < 100)
            sw.Write("5");
        else if (100 < x)
            sw.Write("6");

        sw.Close();

        content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "spentpoints.txt"))
        {
            content = reader.ReadToEnd();
        }
        int y = System.Convert.ToInt32(content);
        sw = new StreamWriter(Application.dataPath + "/data/" + "unspentpoints.txt");
        sw.Write((x - y).ToString());
        sw.Close();

    }

    // Update is called once per frame
    void Update () {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                i = 1;
            }
            if (i == 1)
            {
                float step = speed * Time.deltaTime;
                camera.transform.position = Vector3.MoveTowards(camera.transform.position, destination.position, step);
            }
            if (camera.transform.position == destination.position)
                i = 0;
        }
	
    
}
