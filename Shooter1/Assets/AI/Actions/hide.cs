using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class hide : RAINAction
{
	enemy body;

    public override void Start(RAIN.Core.AI ai)
	{
		body = ai.WorkingMemory.GetItem<enemy> ("body");

        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		
		body = ai.Body.GetComponentInChildren<enemy>();
		body.GetComponent<Collider>().isTrigger = true;
		body.canBeDamaged = false;

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}