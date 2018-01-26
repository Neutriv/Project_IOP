using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Timers;
using System.Collections;
using System;

public class Dash : Skill {

    private float x = 0.1f;
    private float timeStamp = 0f;
    private float coolDown = 2f;
    private float smooth = 1f;

    public bool dashing;

    public bool drawingGUI = false;
    public bool w = false;
    public bool a = false;
    public bool s = false;
    public bool d = false;

    public bool allowkey = true;


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
            }
        }

        if (allowkey)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                a = true;
                w = true;
                s = false;
                d = false;
            }
        }
        if (allowkey)
        {
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                d = true;
                w = true;
                s = false;
                a = false;
            }
        }
        if (allowkey)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                a = true;
                s = true;
                w = false;
                d = false;
            }
        }
        if (allowkey)
        {
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                d = true;
                s = true;
                w = false;
                a = false;
            }
        }

        GameObject Obiekt = GameObject.Find("Player");
        Player player = Obiekt.GetComponent<Player>();
        if (player.dash_lvl1)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {

                if (timeStamp + coolDown <= Time.time)
                {
                    drawingGUI = true;
                    timeStamp = Time.time;
                }
            }
        }


        }

        void OnGUI()
        {

        if (drawingGUI && w && a)
        {
            dashing = true;
            allowkey = false;
            if (x >= 0)
            {
                transform.Translate(Vector3.forward * ((float)x*Mathf.Sqrt(2)/2));
                transform.Translate(Vector3.left * ((float)x*Mathf.Sqrt(2)/2));
                x = x - 0.001f;
                if (x < 0.02f)
                {
                    dashing = false;
                    drawingGUI = false;
                    x = 0.1f;
                    allowkey = true;
                }
            }
        }
        else if (drawingGUI && w && d)
        {
            dashing = true;
            allowkey = false;
            if (x >= 0)
            {
                transform.Translate(Vector3.forward * ((float)x * Mathf.Sqrt(2) / 2));
                transform.Translate(Vector3.right * ((float)x * Mathf.Sqrt(2) / 2));
                x = x - 0.001f;
                if (x < 0.02f)
                {
                    dashing = false;
                    drawingGUI = false;
                    x = 0.1f;
                    allowkey = true;
                }
            }
        }
        else if (drawingGUI && s && a)
        {
            dashing = true;
            allowkey = false;
            if (x >= 0)
            {
                transform.Translate(Vector3.back * ((float)x * Mathf.Sqrt(2) / 2));
                transform.Translate(Vector3.left * ((float)x * Mathf.Sqrt(2) / 2));
                x = x - 0.001f;
                if (x < 0.02f)
                {
                    dashing = false;
                    drawingGUI = false;
                    x = 0.1f;
                    allowkey = true;
                }
            }
        }
        else if (drawingGUI && s && d)
        {
            dashing = true;
            allowkey = false;
            if (x >= 0)
            {
                transform.Translate(Vector3.back * ((float)x * Mathf.Sqrt(2) / 2));
                transform.Translate(Vector3.right * ((float)x * Mathf.Sqrt(2) / 2));
                x = x - 0.001f;
                if (x < 0.02f)
                {
                    dashing = false;
                    drawingGUI = false;
                    x = 0.1f;
                    allowkey = true;
                }
            }
        }
        else if (drawingGUI && w)
            {
            dashing = true;
            allowkey = false;
                if (x >= 0)
                {
                    transform.Translate(Vector3.forward * (float)x);
                    x = x - 0.001f;
                    if (x < 0.02f)
                    {
                    dashing = false;
                    drawingGUI = false;
                        x = 0.1f;
                        allowkey = true;
                    }
                }
            }
            else if (drawingGUI && a)
            {
            dashing = true;
            allowkey = false;
                if (x >= 0)
                {
                    transform.Translate(Vector3.left * (float)x);
                    x = x - 0.001f;
                    if (x < 0.02f)
                    {
                    dashing = false;
                    drawingGUI = false;
                        x = 0.1f;
                        allowkey = true;
                    }
                }
            }
            else if (drawingGUI && s)
            {
            dashing = true;
            allowkey = false;
                if (x >= 0)
                {
                    transform.Translate(Vector3.back * (float)x);
                    x = x - 0.001f;
                    if (x < 0.02f)
                    {
                    dashing = false;
                    drawingGUI = false;
                        x = 0.1f;
                        allowkey = true;
                    }
                }
            }
            else if (drawingGUI && d)
            {
            dashing = true;
            allowkey = false;
                if (x >= 0)
                {
                    transform.Translate(Vector3.right * (float)x);
                    x = x - 0.001f;
                    if (x < 0.02f)
                    {
                    dashing = false;
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
