using UnityEngine;
using TMPro;

public class ShopCardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text cardNameUI;
    [SerializeField] private TMP_Text cardCostUI;
    public void SetCardInfo(string cardName, int cardCost)
    {
        cardNameUI.text = cardName;
        cardCostUI.text = cardCost.ToString();
    }
}
