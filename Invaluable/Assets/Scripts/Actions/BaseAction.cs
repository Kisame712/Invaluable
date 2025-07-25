
using System;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    protected bool isActive;
    protected Player player;
    protected bool actionToBeDisplayed;

    protected virtual void Awake()
    {
        player = GetComponent<Player>();
    }

    public abstract string GetActionName();

    public abstract void TakeAction();

    public bool IsActionToBeDisplayed()
    {
        return actionToBeDisplayed;
    }
}
