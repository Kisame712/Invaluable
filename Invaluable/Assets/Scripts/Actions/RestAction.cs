using UnityEngine;

public class RestAction : BaseAction
{
    public override string GetActionName()
    {
        return "REST";
    }

    public override void TakeAction()
    {
        Debug.Log("Taking Rest Action");
    }
}
