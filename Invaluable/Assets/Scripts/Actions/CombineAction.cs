using UnityEngine;
using System;
public class CombineAction : BaseAction
{
    [SerializeField] private GameObject combineSpellsMenu;
    [SerializeField] private GameObject buySpellsButton;
    [SerializeField] private GameObject playerActionSystemUI;
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
        playerActionSystemUI.SetActive(false);
        buySpellsButton.SetActive(false);
        combineSpellsMenu.SetActive(true);
    }
}
