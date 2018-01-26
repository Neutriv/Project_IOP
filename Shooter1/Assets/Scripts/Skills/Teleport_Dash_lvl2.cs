using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Dash_lvl2 : MonoBehaviour {

    public bool drawingGUI = false;
    public bool w = false;
    public bool a = false;
    public bool s = false;
    public bool d = false;
    public bool allowkey = true;

    public bool teleporting;
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
        if (player.dash_lvl2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if ((timeStamp + coolDown) <= Time.time)
                    {
                    drawingGUI = true;
                    timeStamp = Time.time;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
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
        if (drawingGUI && w && a)
        {
            teleporting = true;
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
            Ray leftRay = new Ray(transform.position, Vector3.left);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(forwardRay, x) && !Physics.Raycast(leftRay, x))
                {
                    teleporting = false;
                    transform.Translate(Vector3.forward * ((float)x * Mathf.Sqrt(2) / 2));
                    transform.Translate(Vector3.left * ((float)x * Mathf.Sqrt(2) / 2));
                    drawingGUI = false;
                }

                x = x - 0.1f;
            }
            x = 10f;
        }
        else if (drawingGUI && w && d)
        {
            teleporting = true;
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
            Ray rightRay = new Ray(transform.position, Vector3.right);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(forwardRay, x) && !Physics.Raycast(rightRay, x))
                {
                    teleporting = false;
                    transform.Translate(Vector3.forward * ((float)x * Mathf.Sqrt(2) / 2));
                    transform.Translate(Vector3.right * ((float)x * Mathf.Sqrt(2) / 2));
                    drawingGUI = false;
                }
                x = x - 0.1f;
            }
            x = 10f;
        }
        else if (drawingGUI && s && a)
        {
            teleporting = true;
            Ray backRay = new Ray(transform.position, Vector3.back);
            Ray leftRay = new Ray(transform.position, Vector3.left);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(backRay, x) && !Physics.Raycast(leftRay, x))
                {
                    teleporting = false;
                    transform.Translate(Vector3.back * ((float)x * Mathf.Sqrt(2) / 2));
                    transform.Translate(Vector3.left * ((float)x * Mathf.Sqrt(2) / 2));
                    drawingGUI = false;
                }
                x = x - 0.1f;
            }
            x = 10f;
        }
        else if (drawingGUI && s && d)
        {
            teleporting = true;
            Ray backRay = new Ray(transform.position, Vector3.back);
            Ray rightRay = new Ray(transform.position, Vector3.right);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(backRay, x) && !Physics.Raycast(rightRay, x))
                {
                    teleporting = false;
                    transform.Translate(Vector3.back * ((float)x * Mathf.Sqrt(2) / 2));
                    transform.Translate(Vector3.right * ((float)x * Mathf.Sqrt(2) / 2));
                    drawingGUI = false;
                }
                x = x - 0.1f;
            }
            x = 10f;
        }
        else if (drawingGUI && a)
        {
            teleporting = true;
            Ray leftRay = new Ray(transform.position, Vector3.left);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(leftRay, x))
                {
                    teleporting = false;
                    transform.Translate(Vector3.left * (float)x);
                    drawingGUI = false;
                }
                x = x - 0.1f;
            }
            x = 10f;

        }
        else if (drawingGUI && s)
        {
            
            Ray backRay = new Ray(transform.position, Vector3.back);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(backRay, x))
                {
                    teleporting = false;
                    transform.Translate(Vector3.back * (float)x);
                    drawingGUI = false;
                }
                x = x - 0.1f;teleporting = true;
            }
            x = 10f;

        }
        else if (drawingGUI && d)
        {
            teleporting = true;
            Ray rightRay = new Ray(transform.position, Vector3.right);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(rightRay, x))
                {
                    teleporting = false;
                    transform.Translate(Vector3.right * (float)x);
                    drawingGUI = false;
                }
                x = x - 0.1f;
            }
            x = 10f;
        }
        else if (drawingGUI && w)
        {
            teleporting = true;
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
            while (x > 1 && drawingGUI)
            {
                if (!Physics.Raycast(forwardRay, x))
                {
                    teleporting = false;
                    transform.Translate(Vector3.forward * (float)x);
                    drawingGUI = false;
                }
                x = x - 0.1f;
            }
            x = 10f;
        }
    }

}
