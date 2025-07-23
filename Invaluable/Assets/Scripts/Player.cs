using UnityEngine;

public class Player : MonoBehaviour
{
    private UseSpellAction useSpellAction;
    private SpellUsedAction spellUsedAction;
    private BaseAction[] baseActionArray;

    private void Awake()
    {
        useSpellAction = GetComponent<UseSpellAction>();
        baseActionArray = GetComponents<BaseAction>();
        spellUsedAction = GetComponent<SpellUsedAction>();
    }


    public UseSpellAction GetUseSpellAction()
    {
        return useSpellAction;
    }

    public BaseAction[] GetBaseActions()
    {
        return baseActionArray;
    }

    public SpellUsedAction GetSpellUsedAction()
    {
        return spellUsedAction;
    }

    public void PlaySpellAnimations()
    {
        Debug.Log("Playing card animation");
    }
}
