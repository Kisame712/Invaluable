using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { private set; get; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance of ResourceManager" + Instance);
            Destroy(Instance);
            return;
        }
        Instance = this;
    }

    [SerializeField] private BaseCard[] allCards;

    public BaseCard GetCard(int index)
    {
        return new BaseCard
        {
            cardCost = allCards[index].cardCost,
            cardName = allCards[index].cardName,
            isCombined = allCards[index].isCombined,
            damageAmount = allCards[index].damageAmount
        };
    }

    public BaseCard GetCardThroughName(string cardName)
    {
       foreach(BaseCard baseCard in allCards)
        {
            if(cardName == baseCard.cardName)
            {
                return baseCard;
            }
        }
        return null;
    }

    public int GetTotalLength()
    {
        return allCards.Length;
    }

}
