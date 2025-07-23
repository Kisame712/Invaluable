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
        SpellCardUI.OnAnySpellButtonClicked += SpellCardUI_OnAnySpellButtonClicked;

        UpdateCurrentPlayerCards();
    }

    private void UpdateCurrentPlayerCards()
    {
        Dictionary<string, int> playerBaseCardMap = PlayerCardManager.Instance.GetPlayerCards();
        foreach (KeyValuePair<string, int> item in playerBaseCardMap)
        {
            BaseCard baseCard = PlayerCardManager.Instance.GetBaseCard(item.Key);
            int cardCount = item.Value;
            if (cardCount != 0)
            {
                Transform cardPrefabTransform = Instantiate(spellUIPrefab, spellCardHolder);
                SpellCardUI spellCard = cardPrefabTransform.GetComponent<SpellCardUI>();
                spellCard.SetCardInfo(baseCard, cardCount);
            }

        }
    }

    private void SpellCardUI_OnAnyButtonClicked(object sender, EventArgs e)
    {
        ClearCards();
        UpdateCurrentPlayerCards();
    }

    private void SpellCardUI_OnAnySpellButtonClicked(object sender, EventArgs e)
    {
        ClearCards();
        UpdateCurrentPlayerCards();
    }

    private void ClearCards()
    {
       foreach(Transform transform in spellCardHolder)
        {
            Destroy(transform.gameObject);
        }
    }
}
