using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLock : MonoBehaviour {

    public GameObject cube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y+1f, cube.transform.position.z);

    }
}
