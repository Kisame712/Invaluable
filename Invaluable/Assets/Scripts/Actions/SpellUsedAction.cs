using UnityEngine;
using System;
using System.Collections;
public class SpellUsedAction : BaseAction
{
    [SerializeField] private GameObject spellMenu;
    [SerializeField] private GameObject buySpellsButton;
    [SerializeField] private GameObject playerActionSystemUI;
    [SerializeField] private GameObject endTurnButton;

    protected override void Awake()
    {
        base.Awake();
        actionToBeDisplayed = false;

    }
    public override string GetActionName()
    {
        return "SpellUsed";
    }

    public override void TakeAction()
    {
        return;
    }

    public void CastSpell(BaseCard baseCard)
    {
        PlayerCardManager.Instance.PlayerCardUsed(baseCard.cardName);
        spellMenu.SetActive(false);
        player.PlaySpellAnimations(baseCard); 
        PlayerActionSystem.Instance.ActionTaken();
        StartCoroutine(ResetUI());

    }

    IEnumerator ResetUI()
    {
        yield return new WaitForSeconds(1);
        buySpellsButton.SetActive(true);
        playerActionSystemUI.SetActive(true);
        endTurnButton.SetActive(true);
    }
}
