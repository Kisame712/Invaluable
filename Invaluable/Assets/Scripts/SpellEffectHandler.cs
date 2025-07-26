using UnityEngine;
using System.Collections.Generic;

public class SpellEffectHandler : MonoBehaviour
{
    [SerializeField] private List<BaseCard> allBaseCards;
    [SerializeField] private List<GameObject> allCardEffects;

    public static SpellEffectHandler Instance { private set; get; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one instance of SpellEffectHandler" + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private BaseCard GetBaseCardThroughName(string cardName)
    {
        foreach(BaseCard baseCard in allBaseCards)
        {
            if(baseCard.cardName == cardName)
            {
                return baseCard;
            }
        }

        return null;
    }

    public void PlayLinkedAnimationEffects(string cardName, Transform spawnPosition, Transform enemyPosition)
    {
        BaseCard baseCard = GetBaseCardThroughName(cardName);

        int index = allBaseCards.IndexOf(baseCard);

        GameObject spellEffect = Instantiate(allCardEffects[index], spawnPosition.position, Quaternion.identity);

        BaseSpellEffect spellEffectComponent = spellEffect.GetComponent<BaseSpellEffect>();

        spellEffectComponent.SetTargetPosition(enemyPosition);
    }

   
}
