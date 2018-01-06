using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Rivalshoot : RAINAction
{

	EnemyBasic enemyshoot;
    public override void Start(RAIN.Core.AI ai)
	{enemyshoot = ai.WorkingMemory.GetItem<EnemyBasic> ("enemyshoot");
		//enemyshoot.canShoot = true;
		
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
	{
		
		enemyshoot = ai.Body.GetComponentInChildren<EnemyBasic>();
		//enemyshoot.Start ();
		//enemyshoot.Update ();
		//enemyshoot.canShoot=true;
		if (enemyshoot.canShoot == true) {
			enemyshoot.Shoot ();
			enemyshoot.canShoot = false;
		}

		//yield return new WaitForSeconds(0.4f);

		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
		//enemyshoot.canShoot = true;
        base.Stop(ai);
    }
}