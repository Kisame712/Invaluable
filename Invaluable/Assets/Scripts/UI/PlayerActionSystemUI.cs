using UnityEngine;

public class PlayerActionSystemUI : MonoBehaviour
{
    [SerializeField] private Transform actionButtonContainer;
    [SerializeField] private Transform actionButtonPrefab;

    private void Start()
    {
        CreateActionButtons();
    }

    private void CreateActionButtons()
    {
        Player player = PlayerActionSystem.Instance.GetPlayer();

        foreach(BaseAction baseAction in player.GetBaseActions())
        {
            Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainer);
            ActionButtonUI actionButton = actionButtonTransform.GetComponent<ActionButtonUI>();
            actionButton.SetActionName(baseAction);
        }
    }

}
