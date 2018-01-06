using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sferra : MonoBehaviour {

	SphereCollider Sphere;

	// Use this for initialization
	void Start () {
		Sphere = GetComponent<SphereCollider>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider player){
		if (player.gameObject.name == "Player") {
			Sphere.isTrigger = false;
		}
		else Sphere.isTrigger = true;

	}
}
