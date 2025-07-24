using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class ShopCardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text cardNameUI;
    [SerializeField] private TMP_Text cardCostUI;
    public static event EventHandler OnAnyButtonClicked;
    private BaseCard baseCard;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void SetCardInfo(BaseCard baseCard)
    {
        cardNameUI.text = baseCard.cardName;
        cardCostUI.text = baseCard.cardCost.ToString();
        this.baseCard = baseCard;
    }

    public BaseCard GetBaseCard()
    {
        return baseCard;
    }

    private void Start()
    {
        if(button.interactable == true)
        {
            button.onClick.AddListener(UpdateButtonStatus);
        }
    }

    public void SetButtonStatus()
    {
        if (baseCard != null)
        {
            if (TimeSlotManager.Instance.CanBuyCard(baseCard))
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }

        }
    }
    
    private void UpdateButtonStatus()
    {
        if (baseCard != null && TimeSlotManager.Instance.CanBuyCard(baseCard))
        {
            PlayerCardManager.Instance.AddPlayerCard(baseCard.cardName);
            TimeSlotManager.Instance.BoughtCard(baseCard.cardCost);
            OnAnyButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }

}
