using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;

public class emterMenu : MonoBehaviour {
    public int i = 0;
    public Transform destination;
    public float speed = 2.0f;
    public GameObject camera;
    //StreamWriter sw;
	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt("resolution",0) == 0)
            Screen.SetResolution(1440, 900, true);
        if (PlayerPrefs.GetInt("resolution", 0) == 1)
            Screen.SetResolution(1680, 1050, true);
        if (PlayerPrefs.GetInt("resolution", 0) == 2)
            Screen.SetResolution(1920, 1080, true);
        if (PlayerPrefs.GetInt("fullscreen", 0) == 0)
            Screen.fullScreen = false;
        if (PlayerPrefs.GetInt("fullscreen", 0) == 1)
            Screen.fullScreen = true;

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
