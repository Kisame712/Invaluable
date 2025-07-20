using UnityEngine;

public class BaseCard : MonoBehaviour
{
    protected int cardCost;
    protected int damage;

    protected bool isCombined;

    public bool IsCardCombined()
    {
        return isCombined;
    }

    public int GetCardCost()
    {
        return cardCost;
    }

    public int GetDamageAmount()
    {
        return damage;
    }
    
}
