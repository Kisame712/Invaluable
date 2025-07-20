using UnityEngine;

public class CardHolderUI : MonoBehaviour
{
    [SerializeField] private Transform cardHolderParent;
    [SerializeField] private Transform cardUIPrefab;

    private void Start()
    {
       for(int i =0; i<ResourceManager.Instance.GetTotalLength(); i++)
        {
            BaseCard baseCard = ResourceManager.Instance.GetCard(i);
            if (!baseCard.isCombined)
            {
                Transform cardPrefabTransform = Instantiate(cardUIPrefab, cardHolderParent);
                ShopCardUI shopCardUI = cardPrefabTransform.GetComponent<ShopCardUI>();
                shopCardUI.SetCardInfo(baseCard.cardName, baseCard.cardCost);
            }

        }
        
    }
}
