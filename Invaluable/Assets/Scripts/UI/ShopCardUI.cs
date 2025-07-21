using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class ShopCardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text cardNameUI;
    [SerializeField] private TMP_Text cardCostUI;
    public static event EventHandler OnAnyButtonClicked;

    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void SetCardInfo(string cardName, int cardCost)
    {
        cardNameUI.text = cardName;
        cardCostUI.text = cardCost.ToString();
    }

    private void Update()
    {
        button.onClick.AddListener(() =>
        {
            OnAnyButtonClicked?.Invoke(this, EventArgs.Empty);
        });
    }
}
