using UnityEngine;
using System;
public class PlayerActionSystemUI : MonoBehaviour
{
    [SerializeField] private Transform actionButtonContainer;
    [SerializeField] private Transform actionButtonPrefab;

    private void OnDestroy()
    {
        PlayerActionSystem.Instance.OnActionPointsZero -= PlayerActionSystem_OnActionPointsZero;
        Enemy.OnEnemyTurnEnded -= Enemy_OnEnemyTurnEnded;
    }

    private void Start()
    {
        CreateActionButtons();

        PlayerActionSystem.Instance.OnActionPointsZero += PlayerActionSystem_OnActionPointsZero;
        Enemy.OnEnemyTurnEnded += Enemy_OnEnemyTurnEnded;
    }

    private void CreateActionButtons()
    {
        Player player = PlayerActionSystem.Instance.GetPlayer();

        foreach(BaseAction baseAction in player.GetBaseActions())
        {
            if(baseAction.IsActionToBeDisplayed() == false)
            {
                continue;
            }
            Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainer);
            ActionButtonUI actionButton = actionButtonTransform.GetComponent<ActionButtonUI>();
            actionButton.SetActionName(baseAction);
        }
    }


    private void PlayerActionSystem_OnActionPointsZero(object sender, EventArgs e)
    {
        foreach (Transform actionButton in actionButtonContainer)
        {
            Destroy(actionButton.gameObject);
        }
    }

    private void Enemy_OnEnemyTurnEnded(object sender, EventArgs e)
    {
        foreach (Transform actionButton in actionButtonContainer)
        {
            Destroy(actionButton.gameObject);
        }
        CreateActionButtons();
    }
}
