using UnityEngine;
using System;
public class UseSpellAction : BaseAction
{
    [SerializeField] private GameObject spellMenu;
    [SerializeField] private GameObject playerActionsUI;
    [SerializeField] private GameObject shopButton;

    protected override void Awake()
    {
        base.Awake();
        actionToBeDisplayed = true;

    }
    public override string GetActionName()
    {
        return "SPELL";
    }

    public override void TakeAction(Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        playerActionsUI.SetActive(false);
        shopButton.SetActive(false);
        spellMenu.SetActive(true);
    }


}
