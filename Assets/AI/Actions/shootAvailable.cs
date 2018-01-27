using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class shootAvailable : RAINAction
{
	EnemyBasic enemyshoot;
	public override void Start(RAIN.Core.AI ai)
	{enemyshoot = ai.WorkingMemory.GetItem<EnemyBasic> ("enemyshoot");
		base.Start(ai);
	}

	public override ActionResult Execute(RAIN.Core.AI ai)
	{

		enemyshoot = ai.Body.GetComponentInChildren<EnemyBasic>();
		enemyshoot.canShoot=true;
		return ActionResult.FAILURE;
	}

	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}