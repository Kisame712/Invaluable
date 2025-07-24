using UnityEngine;
using TMPro;
using System;
public class TimeSlotManager : MonoBehaviour
{
    public static TimeSlotManager Instance { private set; get; }

    [SerializeField] private TMP_Text timeSlotsDisplay;

    [SerializeField] private int playerTimeSlots;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance of TimeSlotManager" + Instance);
            Destroy(Instance);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UpdatePlayerTimeSlots();

        ShopCardUI.OnAnyButtonClicked += ShopCardUI_OnAnyButtonClicked;
    }

    private void UpdatePlayerTimeSlots()
    {
        timeSlotsDisplay.text = $"Time Slots : {playerTimeSlots}";
    }

    public bool CanBuyCard(BaseCard card)
    {
        if(card.cardCost <= playerTimeSlots)
        {
            return true;
        }
        return false;
    }

    public void BoughtCard(int amount)
    {
        playerTimeSlots -= amount;
        if(playerTimeSlots < 0)
        {
            playerTimeSlots = 0;
        }
    }

    private void ShopCardUI_OnAnyButtonClicked(object sender, EventArgs e)
    {
        Debug.Log("shop button clicked!!");
        UpdatePlayerTimeSlots();
    }
}
