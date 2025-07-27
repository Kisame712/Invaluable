using UnityEngine;
using System;
public class CardHolderUI : MonoBehaviour
{
    [SerializeField] private Transform cardHolderParent;
    [SerializeField] private Transform cardUIPrefab;

    private void Start()
    {
        SetBaseSpells();

        ShopCardUI.OnAnyButtonClicked += ShopCardUI_OnAnyButtonClicked;
        Enemy.OnEnemyTurnEnded += Enemy_OnEnemyTurnEnded;
    }

    private void SetBaseSpells()
    {
        for (int i = 0; i < ResourceManager.Instance.GetTotalLength(); i++)
        {
            BaseCard baseCard = ResourceManager.Instance.GetCard(i);
            if (!baseCard.isCombined)
            {
    
                Transform cardPrefabTransform = Instantiate(cardUIPrefab, cardHolderParent);
                ShopCardUI shopCardUI = cardPrefabTransform.GetComponent<ShopCardUI>();
                shopCardUI.SetCardInfo(baseCard);
            }

        }
    }

    private void ShopCardUI_OnAnyButtonClicked(object sender, EventArgs e)
    {
        ChangeShopButtonStatus();
    }
    private void ChangeShopButtonStatus()
    {
        foreach(Transform buttonTransform in cardHolderParent)
        {
            ShopCardUI shopCard = buttonTransform.GetComponent<ShopCardUI>();
            shopCard.SetButtonStatus();
        }
    }

    private void Enemy_OnEnemyTurnEnded(object sender, EventArgs e)
    {
        ChangeShopButtonStatus();
    }
}
