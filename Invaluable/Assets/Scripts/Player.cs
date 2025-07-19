using UnityEngine;

public class Player : MonoBehaviour
{
    private UseSpellAction useSpellAction;
    private BaseAction[] baseActionArray;

    private void Awake()
    {
        useSpellAction = GetComponent<UseSpellAction>();
        baseActionArray = GetComponents<BaseAction>();
    }


    public UseSpellAction GetUseSpellAction()
    {
        return useSpellAction;
    }

    public BaseAction[] GetBaseActions()
    {
        return baseActionArray;
    }
}
