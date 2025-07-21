using UnityEngine;
using System;
using System.Collections.Generic;
public class PlayerCardManager : MonoBehaviour
{
    public static PlayerCardManager Instance { private set; get; }

    private Dictionary<BaseCard, int> playerCards = new Dictionary<BaseCard, int>();

    [SerializeField] private BaseCard[] initalCards;
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

    public Dictionary<BaseCard, int> GetPlayerCards()
    {
        return playerCards;
    }

    public void AddPlayerCard(BaseCard baseCard)
    {
        playerCards[baseCard]++;
    }
    public void PlayerCardUsed(BaseCard baseCard)
    {
        playerCards[baseCard]--;
    }
    
    public bool CanUsePlayerCard(BaseCard baseCard)
    {
        if (playerCards[baseCard] > 0)
        {
            return true;
        }
        return false;
    }

    private void MakePlayerCardDictionary()
    {
        foreach(BaseCard baseCard in initalCards)
        {
            playerCards.Add(baseCard, initialCardCounts);
        }
    }
}
