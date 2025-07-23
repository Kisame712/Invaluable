
using System;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    protected int actionPoints;
    protected bool isActive;
    protected Player player;
    protected bool actionToBeDisplayed;

    public Action onActionComplete;
    protected virtual void Awake()
    {
        player = GetComponent<Player>();
    }

    public abstract string GetActionName();

    public abstract void TakeAction(Action onActionComplete);

    public bool IsActionToBeDisplayed()
    {
        return actionToBeDisplayed;
    }
}
