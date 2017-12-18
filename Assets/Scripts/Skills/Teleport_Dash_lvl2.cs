using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Dash_lvl2 : MonoBehaviour {

    public bool drawingGUI = false;
    public bool w = false;
    public bool a = false;
    public bool s = false;
    public bool d = false;
    public bool dash_w = false;
    public bool dash_a = false;
    public bool dash_s = false;
    public bool dash_d = false;
    public bool allowkey = true;

    private float x = 10f;

    public float z = 10f;
    private float timeStamp = 0f;
    private float coolDown = 2f;
    private float smooth = 1f;



    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (allowkey)
        {
            if (Input.GetKey(KeyCode.A))
            {
                a = true;
                s = false;
                w = false;
                d = false;
                dash_a = true;
                dash_d = false;
                dash_s = false;
                dash_w = false;
            }
        }

        if (allowkey)
        {
            if (Input.GetKey(KeyCode.S))
            {
                s = true;
                a = false;
                w = false;
                d = false;
                dash_s = true;
                dash_a = false;
                dash_d = false;
                dash_w = false;
            }
        }

        if (allowkey)
        {
            if (Input.GetKey(KeyCode.D))
            {
                d = true;
                w = false;
                a = false;
                s = false;
                dash_d = true;
                dash_a = false;
                dash_s = false;
                dash_w = false;
            }
        }

        if (allowkey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                w = true;
                a = false;
                s = false;
                d = false;
                dash_w = true;
                dash_a = false;
                dash_d = false;
                dash_s = false;
            }
        }



        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (timeStamp + coolDown <= Time.time)
            {
                drawingGUI = true;
                timeStamp = Time.time;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            drawingGUI = false;
        }
            /*
            RaycastHit hit;
            Ray landingRay = new Ray(transform.position, Vector3.left);
            //Debug.DrawRay(transform.position, Vector3.left * deplymentHeight);
            if(Physics.Raycast(landingRay, 1))
            {
                    transform.Translate(Vector3.forward * (float)z);
            }
            */


        }

    void OnGUI()
    {
        if (drawingGUI && w && dash_w)
        {
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(forwardRay, x))
                {
                    transform.Translate(Vector3.forward * (float)x);
                    drawingGUI = false;
                }
                x = x - 0.1f;
            }
            x = 10f;
        }
        else if (drawingGUI && a && dash_a)
        {
            Ray leftRay = new Ray(transform.position, Vector3.left);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(leftRay, x))
                {
                    transform.Translate(Vector3.left * (float)x);
                    drawingGUI = false;
                }
                x = x - 0.1f;
            }
            x = 10f;

        }
        else if (drawingGUI && s && dash_s)
        {
            Ray backRay = new Ray(transform.position, Vector3.back);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(backRay, x))
                {
                    transform.Translate(Vector3.back * (float)x);
                    drawingGUI = false;
                }
                x = x - 0.1f;
            }
            x = 10f;

        }
        else if (drawingGUI && d && dash_d)
        {
            Ray rightRay = new Ray(transform.position, Vector3.right);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(rightRay, x))
                {
                    transform.Translate(Vector3.right * (float)x);
                    drawingGUI = false;
                }
                x = x - 0.1f;
            }
            x = 10f;
        }
    }

}
