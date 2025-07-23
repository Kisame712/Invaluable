using UnityEngine;
using System;
using System.Collections.Generic;
public class PlayerCardManager : MonoBehaviour
{
    public static PlayerCardManager Instance { private set; get; }

    private Dictionary<string, int> playerCards = new Dictionary<string, int>();

    [SerializeField] private List<BaseCard> initalCards;
    [SerializeField] private int initialCardCounts;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of PlayerCardManager" + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        MakePlayerCardDictionary();
    }

    public Dictionary<string, int> GetPlayerCards()
    {
        return playerCards;
    }

    public void AddPlayerCard(string baseCard)
    {
        if (playerCards.ContainsKey(baseCard))
        {
            playerCards[baseCard]++;
        }
        else
        {
            playerCards.Add(baseCard, 1);
            BaseCard cardToAdd = ResourceManager.Instance.GetCardThroughName(baseCard);
            initalCards.Add(cardToAdd);    
        }
    }
    public void PlayerCardUsed(string baseCard)
    {
        playerCards[baseCard]--;
        if (playerCards[baseCard] == 0)
        {
            playerCards.Remove(baseCard);
        }

    }
    

    private void MakePlayerCardDictionary()
    {
        foreach(BaseCard baseCard in initalCards)
        {
            playerCards.Add(baseCard.cardName, initialCardCounts);
        }
    }

    public BaseCard GetBaseCard(string cardName)
    {
        foreach(BaseCard baseCard in initalCards)
        {
            if(baseCard.cardName == cardName)
            {
                return baseCard;
            }
        }
        return null;
    }
}
