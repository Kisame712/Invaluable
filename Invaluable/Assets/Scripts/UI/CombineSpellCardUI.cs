using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CombineSpellCardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text cardNameUI;
    [SerializeField] private TMP_Text cardCountUI;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Button button;

    private BaseCard baseCard;

    public static event EventHandler<BaseCard> OnAnyCombineSpellButtonClicked;

    public void SetCardInfo(BaseCard baseCard, int cardCount)
    {
        this.baseCard = baseCard;
        cardNameUI.text = baseCard.cardName;
        cardCountUI.text = $"x {cardCount}";
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            if (baseCard != null)
            {
                audioSource.Play();
                OnAnyCombineSpellButtonClicked?.Invoke(this, baseCard);
            }

        });
    }
}
