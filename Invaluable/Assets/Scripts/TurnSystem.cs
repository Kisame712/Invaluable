using UnityEngine;
using TMPro;
using System;

public class TurnSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemyTurnText;
    [SerializeField] private GameObject buySpellsButton;
    [SerializeField] private GameObject nextTurnButton;
    [SerializeField] private GameObject playerInputActionsUI;

    public static TurnSystem Instance { private set; get; }
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one instance of TurnSystem!!" + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void OnDestroy()
    {
        Enemy.OnEnemyTurnEnded -= Enemy_OnEnemyTurnEnded;
    }
    private void Start()
    {
        Enemy.OnEnemyTurnEnded += Enemy_OnEnemyTurnEnded;
    }

    public void PlayerTurnEnded()
    {
        buySpellsButton.SetActive(false);
        nextTurnButton.SetActive(false);
        playerInputActionsUI.SetActive(false);
        Enemy enemy = FindFirstObjectByType<Enemy>();
        enemy.EnemyTurn();
    }

    private void Enemy_OnEnemyTurnEnded(object sender, EventArgs e)
    {
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        buySpellsButton.SetActive(true);
        nextTurnButton.SetActive(true);
        playerInputActionsUI.SetActive(true);
        PlayerActionSystem.Instance.ResetActionPoints();
        TimeSlotManager.Instance.AddTimeAfterTurnEnds();

    }

}
