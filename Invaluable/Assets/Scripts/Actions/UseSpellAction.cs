using UnityEngine;
using System;
public class UseSpellAction : BaseAction
{
    [SerializeField] private GameObject spellMenu;
    [SerializeField] private GameObject playerActionsUI;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject endTurnButton;

    protected override void Awake()
    {
        base.Awake();
        actionToBeDisplayed = true;

    }
    public override string GetActionName()
    {
        return "SPELL";
    }

    public override void TakeAction()
    {
        playerActionsUI.SetActive(false);
        shopButton.SetActive(false);
        endTurnButton.SetActive(false);
        spellMenu.SetActive(true);
    }


}
