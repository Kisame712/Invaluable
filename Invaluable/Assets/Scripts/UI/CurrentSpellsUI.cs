using System.Collections.Generic;
using UnityEngine;
using System;

public class CurrentSpellsUI : MonoBehaviour
{
    [SerializeField] private Transform spellCardHolder;
    [SerializeField] private Transform spellUIPrefab;

    private void Start()
    {
        ShopCardUI.OnAnyButtonClicked += SpellCardUI_OnAnyButtonClicked;

        UpdateCurrentPlayerCards();
    }

    private void UpdateCurrentPlayerCards()
    {
        Dictionary<BaseCard, int> playerBaseCardMap = PlayerCardManager.Instance.GetPlayerCards();
        foreach (KeyValuePair<BaseCard, int> item in playerBaseCardMap)
        {
            BaseCard baseCard = item.Key;
            int cardCount = item.Value;
            if (cardCount != 0)
            {
                Transform cardPrefabTransform = Instantiate(spellUIPrefab, spellCardHolder);
                SpellCardUI spellCard = cardPrefabTransform.GetComponent<SpellCardUI>();
                spellCard.SetCardInfo(baseCard.cardName, baseCard.damageAmount, cardCount);
            }

        }
    }

    private void SpellCardUI_OnAnyButtonClicked(object sender, EventArgs e)
    {
        UpdateCurrentPlayerCards();
    }
}
