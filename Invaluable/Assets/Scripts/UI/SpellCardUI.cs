using TMPro;
using UnityEngine;
using System;

public class SpellCardUI : MonoBehaviour
{

    [SerializeField] private TMP_Text cardNameUI;
    [SerializeField] private TMP_Text cardDamageUI;
    [SerializeField] private TMP_Text cardCountUI;


    public void SetCardInfo(string cardName, int cardDamage, int cardCount)
    {
        cardNameUI.text = cardName;
        cardDamageUI.text = $"Damage +{cardDamage}";
        cardCountUI.text = $"x {cardCount}";
    }

}
