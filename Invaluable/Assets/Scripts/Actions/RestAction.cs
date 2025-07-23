using UnityEngine;
using System;
public class RestAction : BaseAction
{

    protected override void Awake()
    {
        base.Awake();
        actionToBeDisplayed = true;

    }
    public override string GetActionName()
    {
        return "REST";
    }

    public override void TakeAction(Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        Debug.Log("Taking Rest Action");
    }
}
