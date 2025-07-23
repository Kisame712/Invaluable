using UnityEngine;
using System;
public class SpellUsedAction : BaseAction
{
    [SerializeField] private GameObject spellMenu;
    [SerializeField] private GameObject buySpellsButton;
    [SerializeField] private GameObject playerActionSystemUI;

    protected override void Awake()
    {
        base.Awake();
        actionToBeDisplayed = false;

    }
    public override string GetActionName()
    {
        return "SpellUsed";
    }

    public override void TakeAction(Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
    }

    public void CastSpell(BaseCard baseCard)
    {
        PlayerCardManager.Instance.PlayerCardUsed(baseCard.cardName);
        spellMenu.SetActive(false);
        player.PlaySpellAnimations();
        ResetUI();

    }

    private void ResetUI()
    {
        buySpellsButton.SetActive(true);
        playerActionSystemUI.SetActive(true);
        onActionComplete();
    }
}
