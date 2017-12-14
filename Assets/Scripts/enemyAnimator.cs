using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimator : MonoBehaviour {

    public GameObject cube;
    public float dispSpeed;
    public Animator anim;
    public Vector3 lastPosition;
    // Use this for initialization
    void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
        if (dispSpeed > 0f)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Dash", false);
        }
        if (dispSpeed > 15f)
        {
            anim.SetBool("Dash", true);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("Dash", false);
        }


        Vector3 eulerAngles = cube.transform.rotation.eulerAngles;
        if (eulerAngles.y > 180.0f)
           gameObject.GetComponent<SpriteRenderer>().flipX = true;
//
        else
           gameObject.GetComponent<SpriteRenderer>().flipX = false;


    }

    void FixedUpdate()
    {
        dispSpeed = (((transform.position - lastPosition).magnitude) / Time.deltaTime);
        lastPosition = transform.position;
    }
}
