using UnityEngine;
using System;
using System.Collections;
public class RestAction : BaseAction
{
    [SerializeField] private GameObject healthIncrease;
    [SerializeField] private GameObject playerActionsUI;
    [SerializeField] private GameObject buySpellsButton;
    [SerializeField] private GameObject endTurnButton;
    protected override void Awake()
    {
        base.Awake();
        actionToBeDisplayed = true;

    }
    public override string GetActionName()
    {
        return "REST";
    }

    public override void TakeAction()
    {
        HealthSystem healthSystem = player.GetHealthSystem();
        healthSystem.IncreaseHealthOnRest();
        StartCoroutine(DisplayHealthIncrease());

    }

    IEnumerator DisplayHealthIncrease()
    {
        healthIncrease.SetActive(true);
        playerActionsUI.SetActive(false);
        buySpellsButton.SetActive(false);
        endTurnButton.SetActive(false);
        yield return new WaitForSeconds(1);
        PlayerActionSystem.Instance.ActionTaken();
        healthIncrease.SetActive(false);
        playerActionsUI.SetActive(true);
        buySpellsButton.SetActive(true);
        endTurnButton.SetActive(true);
    }
}
