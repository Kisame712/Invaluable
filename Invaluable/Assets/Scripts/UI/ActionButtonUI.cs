using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI actionName;
    [SerializeField] private Button button;
    [SerializeField] private AudioSource audioSource;
    private BaseAction baseAction;

    public void SetActionName(BaseAction baseAction)
    {
        this.baseAction = baseAction;
        actionName.text = baseAction.GetActionName().ToUpper();
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            if (baseAction != null)
            {
                audioSource.Play();
                baseAction.TakeAction();
            }
        });
     
    }

}
