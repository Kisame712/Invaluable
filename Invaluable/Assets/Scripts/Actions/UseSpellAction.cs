using UnityEngine;

public class UseSpellAction : BaseAction
{
    [SerializeField] private GameObject spellMenu;
    [SerializeField] private GameObject playerActionsUI;
    [SerializeField] private GameObject shopButton;
    public override string GetActionName()
    {
        return "SPELL";
    }

    public override void TakeAction()
    {
        playerActionsUI.SetActive(false);
        shopButton.SetActive(false);
        spellMenu.SetActive(true);
    }

}
