using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;


[RAINAction]
public class enemy_shoot : RAINAction
{	

	//public GameObject bullet;
    public override void Start(RAIN.Core.AI ai)
    {
		
		  
		//shoot = 1;
        base.Start(ai);



    }

    public override ActionResult Execute(RAIN.Core.AI ai)
	{
		/*var loc = Vector3.zero;



		do {

			loc = ai.Kinematic.Position;

			loc.x += Random.Range (-8f, 8f);

			loc.z += Random.Range (-8f, 8f);


		} while (Vector3.Distance (loc, ai.Kinematic.Position) < 2f);



		ai.WorkingMemory.SetItem<Vector3>("TargetPoint", loc);
*/

		//Player.DestroyObject ();
		return ActionResult.SUCCESS;

	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
		
}