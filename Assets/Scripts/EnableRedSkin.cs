using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;

public class EnableRedSkin : MonoBehaviour {
    int i = 0;
    //public StreamWriter sw;
	// Use this for initialization
	void Start () {
		    
        
	}
	
	// Update is called once per frame
	void Update () {
        if (i == 0)
        {
            i++;
            //sw = new StreamWriter(Application.dataPath + "/data/" + "redenabled.txt");
            //sw.Write("1");
            //sw.Close();
            PlayerPrefs.SetInt("redenabled", 1);
            /*
            string content = string.Empty;
            using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "unspentpionts.txt"))
            {
                content = reader.ReadToEnd();
            }
            int x = System.Int32.Parse(content);
            sw = new StreamWriter(Application.dataPath + "/data/" + "unspentpoints.txt");
            sw.Write((x+1).ToString());
            sw.Close();*/
            int temp = PlayerPrefs.GetInt("unspentpoints");
            Debug.Log(temp.ToString());
            PlayerPrefs.SetInt("unspentpoints", (temp + 1));
            PlayerPrefs.SetInt("quickplayenabled", 1);
            PlayerPrefs.Save();
        }

    }
}
