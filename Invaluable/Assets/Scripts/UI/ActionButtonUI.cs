using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI actionName;
    [SerializeField] private Button button;
    private BaseAction baseAction;

    public void SetActionName(BaseAction baseAction)
    {
        this.baseAction = baseAction;
        actionName.text = baseAction.GetActionName().ToUpper();
    }

    public void Update()
    {
        button.onClick.AddListener(() =>
        {
            if (baseAction != null)
            {
                baseAction.TakeAction();
            }
        });
     
    }
}
