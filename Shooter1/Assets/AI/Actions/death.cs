using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class death : RAINAction
{
	enemy enemydeath;
    public override void Start(RAIN.Core.AI ai)
    {
		enemydeath = ai.WorkingMemory.GetItem<enemy> ("enemydeath");
		base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		enemydeath = ai.Body.GetComponentInChildren<enemy>();
		//return ActionResult.FAILURE;
		if (enemydeath.currentHp <= 0) 
		{
			return ActionResult.FAILURE;
		}
		else 
         return ActionResult.SUCCESS;
 
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}