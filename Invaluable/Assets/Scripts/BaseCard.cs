using UnityEngine;

[CreateAssetMenu(fileName = "SpellName", menuName = "Create Card")]
public class BaseCard : ScriptableObject
{
    public int cardCost;
    public int damageAmount;
    public bool isCombined;

    public string cardName;
}
