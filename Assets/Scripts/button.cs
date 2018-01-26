using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

    public int i = 0;
    public Transform destination;
    public float speed = 2.0f;
    public GameObject camera;

    public Sprite unlit;
    public Sprite lit;
    public bool over;

	// Use this for initialization
	private void Update()
    {
        if (over)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {             
               i = 1;
            }
                
            }
        if (i == 1)
        {
            float step = speed * Time.deltaTime;
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, destination.position, step);
        }
        if (camera.transform.position == destination.position)
            i = 0;
        
    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        gameObject.GetComponent<SpriteRenderer>().sprite = lit;
        over = true;
        
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        gameObject.GetComponent<SpriteRenderer>().sprite = unlit;
        over = false;
    }

    public void funkcja()
    {
        Debug.Log("klikło");
    }
}
