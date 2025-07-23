using UnityEngine;
using System;
public class CombineAction : BaseAction
{
    protected override void Awake()
    {
        base.Awake();
        actionToBeDisplayed = true;

    }
    public override string GetActionName()
    {
        return "COMBINE";
    }

    public override void TakeAction(Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        Debug.Log("Taking Combine Action");
    }
}
