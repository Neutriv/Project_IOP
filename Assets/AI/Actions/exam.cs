using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class exam : RAINAction
{ 
	public GameObject gunpoconiewiem;
	public GameObject bullet;
	public GameObject bulletSpawnPoint;
	public GameObject gun;
	public GameObject Player;
	public GameObject Sphere123;
	//SphereCollider Sphere987;
	public GameObject Sphere987;
    public override void Start(RAIN.Core.AI ai)
	{
		
		//asdfs = ai.WorkingMemory.GetItem<Player> ("asdfs");
        base.Start(ai);

		//Sphere123.GetComponent<sferra> ();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
	{
		//Player.GetComponent<Player> ().Shoot;


		Sphere987.GetComponent<SphereCollider> ().isTrigger==true;
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}

