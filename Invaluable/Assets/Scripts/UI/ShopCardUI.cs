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

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            if (baseCard != null)
            {
                PlayerCardManager.Instance.AddPlayerCard(baseCard.cardName);
                OnAnyButtonClicked?.Invoke(this, EventArgs.Empty);
            }
        });
    }
}
