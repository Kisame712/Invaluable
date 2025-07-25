using UnityEngine;
using System;
public class CombineAction : BaseAction
{
    [SerializeField] private GameObject combineSpellsMenu;
    [SerializeField] private GameObject buySpellsButton;
    [SerializeField] private GameObject playerActionSystemUI;
    [SerializeField] private GameObject endTurnButton;
    protected override void Awake()
    {
        base.Awake();
        actionToBeDisplayed = true;

    }
    public override string GetActionName()
    {
        return "COMBINE";
    }

    public override void TakeAction()
    {
        playerActionSystemUI.SetActive(false);
        buySpellsButton.SetActive(false);
        endTurnButton.SetActive(false);
        combineSpellsMenu.SetActive(true);
    }
}
