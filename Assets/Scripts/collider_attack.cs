using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_attack : MonoBehaviour {
	CapsuleCollider Capsule;
	SphereCollider Sphere;

	void Start(){
		Capsule = GetComponent<CapsuleCollider>();
		Sphere = GetComponent<SphereCollider>();
		Capsule.isTrigger = true;
		Sphere.isTrigger = true;
	}
		

	void OnTriggerEnter(Collider player){
		if (player.gameObject.name == "Player") {
			Capsule.isTrigger = false;
		}
		else Capsule.isTrigger = true;
		//Destroy (other.gameObject);
	}
	void OnTriggerExit(Collider ply){
		Capsule.isTrigger = true;
	}

}
