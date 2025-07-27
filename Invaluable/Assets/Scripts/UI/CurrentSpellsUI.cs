using System.Collections.Generic;
using UnityEngine;
using System;

public class CurrentSpellsUI : MonoBehaviour
{

    [SerializeField] private Transform spellCardHolder;
    [SerializeField] private Transform spellUIPrefab;

    private void Awake()
    {
        
        DontDestroyOnLoad(spellCardHolder);
        DontDestroyOnLoad(spellUIPrefab);
    }

    private void OnDestroy()
    {
        ShopCardUI.OnAnyButtonClicked -= ShopCardUI_OnAnyButtonClicked;
        SpellCardUI.OnAnySpellButtonClicked -= SpellCardUI_OnAnySpellButtonClicked;
        CombineSpellsUI.OnCombineSpell -= CombineSpellsUI_OnCombineSpell;

    }

    private void Start()
    {
        ShopCardUI.OnAnyButtonClicked += ShopCardUI_OnAnyButtonClicked;
        SpellCardUI.OnAnySpellButtonClicked += SpellCardUI_OnAnySpellButtonClicked;
        CombineSpellsUI.OnCombineSpell += CombineSpellsUI_OnCombineSpell;

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

    private void ShopCardUI_OnAnyButtonClicked(object sender, EventArgs e)
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

    private void CombineSpellsUI_OnCombineSpell(object sender, EventArgs e)
    {
        ClearCards();
        UpdateCurrentPlayerCards();
    }
}
