using UnityEngine;

public class CombineAction : BaseAction
{

    public override string GetActionName()
    {
        return "COMBINE";
    }

    public override void TakeAction()
    {
        Debug.Log("Taking Combine Action");
    }
}
