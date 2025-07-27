using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombineSpellsUI : MonoBehaviour
{
    [SerializeField] private Transform spellCardHolder;
    [SerializeField] private Transform spellUIPrefab;
    [SerializeField] private Button combineButton;
    [SerializeField] private TMP_Text combineCondition;

    public static event EventHandler OnCombineSpell;

    private List<BaseCard> selectedCards;
    private int clicks = 0;

    private void Awake()
    {
        selectedCards = new List<BaseCard>();
        combineButton.interactable = false;
        combineCondition.text = "";
    }

    private void Start()
    {
        ShopCardUI.OnAnyButtonClicked += ShopCardUI_OnAnyButtonClicked;
        CombineSpellCardUI.OnAnyCombineSpellButtonClicked += CombineSpellCardUI_OnAnySpellButtonClicked;
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
            if (cardCount != 0 && !baseCard.isCombined)
            {
                Transform cardPrefabTransform = Instantiate(spellUIPrefab, spellCardHolder);
                CombineSpellCardUI combineSpellCard = cardPrefabTransform.GetComponent<CombineSpellCardUI>();
                combineSpellCard.SetCardInfo(baseCard, cardCount);
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

    private void CombineSpellCardUI_OnAnySpellButtonClicked(object sender, BaseCard baseCard)
    {
        ClearCards();
        UpdateCurrentPlayerCards();
        clicks++;
        AddCardToSelectedList(baseCard);
        if (clicks == 2)
        {
            DisableAllSelections();
        }
        SetCombinedButtonState();
    }

    private void ClearCards()
    {
        foreach (Transform transform in spellCardHolder)
        {
            Destroy(transform.gameObject);
        }
    }

    public void ClearSelectedCards()
    {
        selectedCards.Clear();
    }

    public void AddCardToSelectedList(BaseCard cardToBeAdded)
    {
        selectedCards.Add(cardToBeAdded);
    }

    public void DisableAllSelections()
    {
        foreach(Transform spellCardTransform in spellCardHolder)
        {
            Button button = spellCardTransform.GetComponent<Button>();
            button.interactable = false;
        }
    }

    public void EnableAllSelections()
    {
        foreach (Transform spellCardTransform in spellCardHolder)
        {
            Button button = spellCardTransform.GetComponent<Button>();
            button.interactable = true;
        }
    }

    public void ResetClicks()
    {
        clicks = 0;
    }

    public void SetCombinedButtonState()
    {
        if (IsCombinationPossible())
        {
            combineButton.interactable = true;
        }
        else
        {
         
            combineButton.interactable = false;
        }
       
    }

    public void MouseHoverEnter()
    {
        if (!IsCombinationPossible())
        {
            if (selectedCards.Count < 2)
            {
                combineCondition.text = "Select 2 cards to combine!";
            }
            else
            {
                combineCondition.text = "Incorrect combination! Click clear and try again!";
            }
        }
        else
        {
            combineCondition.text = "";
        }
    }

    public void MouseHoverExit()
    {
        combineCondition.text = "";
    }


    private bool IsCombinationPossible()
    {
        if (selectedCards.Count != 2)
        {
            return false;
        }

        BaseCard card1 = selectedCards[0];
        BaseCard card2 = selectedCards[1];

        if ((card1.cardName == "Fire Ball" && card2.cardName == "Stone Shower") || 
            (card1.cardName == "Lightning" && card2.cardName == "Water Beam") ||
            (card1.cardName == "Freeze" && card2.cardName == "Water Beam") ||
            (card2.cardName == "Fire Ball" && card1.cardName == "Stone Shower") ||
            (card2.cardName == "Lightning" && card1.cardName == "Water Beam") ||
            (card2.cardName == "Freeze" && card1.cardName == "Water Beam")
            )
        {
            return true;
        }

        return false;
    }

    public void CombineTwoSpells()
    {
        BaseCard card1 = selectedCards[0];
        BaseCard card2 = selectedCards[1];

        if ((card1.cardName == "Fire Ball" && card2.cardName == "Stone Shower") || (card2.cardName == "Fire Ball" && card1.cardName == "Stone Shower"))
        {
            PlayerCardManager.Instance.AddPlayerCard("Fire Shower");
        }
        else if ((card1.cardName == "Lightning" && card2.cardName == "Water Beam") || (card2.cardName == "Lightning" && card1.cardName == "Water Beam"))
        {
            PlayerCardManager.Instance.AddPlayerCard("Moist Shock");
        }
        else
        {
            PlayerCardManager.Instance.AddPlayerCard("Ice Beam");
        }

        PlayerCardManager.Instance.PlayerCardUsed(card1.cardName);
        PlayerCardManager.Instance.PlayerCardUsed(card2.cardName);
        ClearCards();
        ClearSelectedCards();
        ResetClicks();
        UpdateCurrentPlayerCards();
        OnCombineSpell?.Invoke(this, EventArgs.Empty);
    }
}
