using UnityEngine;
using TMPro;
public class PlayerActionSystem : MonoBehaviour
{
    public static PlayerActionSystem Instance { private set; get; }

    [SerializeField] private Player player;
    [SerializeField] private int remainingActionPoints;
    [SerializeField] private TMP_Text actionPointsText;
    private int maxActionPoints;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more then one instance of PlayerActionSystem!" + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;
        maxActionPoints = remainingActionPoints;
    }

    private void Start()
    {
        UpdateActionPoints();
    }

    public Player GetPlayer()
    {
        return player;
    }

    private void UpdateActionPoints()
    {
        actionPointsText.text = $"Remaining actions : {remainingActionPoints}";
    }

    public void ActionTaken()
    {
        remainingActionPoints--;
        UpdateActionPoints();
    }

    public void ResetActionPoints()
    {
        remainingActionPoints = maxActionPoints;
        UpdateActionPoints();
    }

    public int GetActionPoints()
    {
        return remainingActionPoints;
    }
}
