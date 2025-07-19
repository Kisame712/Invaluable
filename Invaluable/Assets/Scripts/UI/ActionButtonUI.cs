using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI actionName;
    [SerializeField] private Button button;

    public void SetActionName(BaseAction baseAction)
    {
        actionName.text = baseAction.GetActionName().ToUpper();
    }
  
}
