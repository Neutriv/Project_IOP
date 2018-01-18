using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnableRedSkin : MonoBehaviour {

    public StreamWriter sw;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<enemy>().currentHp == 0)
        {
            sw = new StreamWriter(Application.dataPath + "/data/" + "redenabled.txt");
            sw.Write("1");
            sw.Close();

            string content = string.Empty;
            using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "unspentpionts.txt"))
            {
                content = reader.ReadToEnd();
            }
            int x = System.Int32.Parse(content);
            sw = new StreamWriter(Application.dataPath + "/data/" + "unspentpoints.txt");
            sw.Write((x+1).ToString());
            sw.Close();
        }


    }
}
