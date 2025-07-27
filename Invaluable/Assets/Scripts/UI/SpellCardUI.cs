using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpellCardUI : MonoBehaviour
{

    [SerializeField] private TMP_Text cardNameUI;
    [SerializeField] private TMP_Text cardDamageUI;
    [SerializeField] private TMP_Text cardCountUI;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Button button;

    private BaseCard baseCard;

    public static event EventHandler OnAnySpellButtonClicked;

    public void SetCardInfo(BaseCard baseCard, int cardCount)
    {
        this.baseCard = baseCard;
        cardNameUI.text = baseCard.cardName;
        cardDamageUI.text = $"Damage +{baseCard.damageAmount}";
        cardCountUI.text = $"x {cardCount}";
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            if (baseCard != null)
            {
                audioSource.Play();
                Player player = PlayerActionSystem.Instance.GetPlayer();
                SpellUsedAction spellUsedAction = player.GetSpellUsedAction();
                spellUsedAction.CastSpell(baseCard);
                OnAnySpellButtonClicked?.Invoke(this, EventArgs.Empty);
            }

        });
    }

}
