using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Timers;
using System.Collections;
using System;

public class Dash : Skill {

    public float x = 0.1f;
    private float timeStamp = 0f;
    private float coolDown = 2f;
    private float smooth = 1f;

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


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        /*
            if (Input.GetKey(KeyCode.X))
            {
                if (timeStamp + coolDown <= Time.time)
                {
                    timeStamp = Time.time;
                    transform.Translate(Vector3.up * (float)x);
                }

            }
            */

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

            if (Input.GetKeyUp(KeyCode.A))
            {
                //  a = false;
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                // s = false;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                // d = false;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                // w = false;
            }

            if (Input.GetKeyUp(KeyCode.X))
            {

            if (timeStamp + coolDown <= Time.time)
            {
                drawingGUI = true;
                timeStamp = Time.time;
            }
            }


        }



        public void Ruch()
        {

            if (x > 0)
            {

                transform.Translate(Vector3.up * (float)x);
                x = x - 0.001f;
            }

        }



        void OnGUI()
        {
            if (drawingGUI && w && dash_w)
            {
                allowkey = false;
                if (x >= 0)
                {
                    transform.Translate(Vector3.forward * (float)x);
                    x = x - 0.001f;
                    if (x < 0.02f)
                    {
                        drawingGUI = false;
                        x = 0.1f;
                        allowkey = true;
                    }
                }
            }
            else if (drawingGUI && a && dash_a)
            {
                allowkey = false;
                if (x >= 0)
                {
                    transform.Translate(Vector3.left * (float)x);
                    x = x - 0.001f;
                    if (x < 0.02f)
                    {
                        drawingGUI = false;
                        x = 0.1f;
                        allowkey = true;
                    }
                }
            }
            else if (drawingGUI && s && dash_s)
            {
                allowkey = false;
                if (x >= 0)
                {
                    transform.Translate(Vector3.back * (float)x);
                    x = x - 0.001f;
                    if (x < 0.02f)
                    {
                        drawingGUI = false;
                        x = 0.1f;
                        allowkey = true;
                    }
                }
            }
            else if (drawingGUI && d && dash_d)
            {
                allowkey = false;
                if (x >= 0)
                {
                    transform.Translate(Vector3.right * (float)x);
                    x = x - 0.001f;
                    if (x < 0.02f)
                    {
                        drawingGUI = false;
                        x = 0.1f;
                        allowkey = true;
                    }
                }
            }
        }

    public override void umiejetnosc()
    {
        throw new NotImplementedException();
    }

}
