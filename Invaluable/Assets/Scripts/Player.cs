using UnityEngine;

public class Player : MonoBehaviour
{
    private UseSpellAction useSpellAction;
    private SpellUsedAction spellUsedAction;
    private BaseAction[] baseActionArray;
    private Animator animator;

    private void Awake()
    {
        useSpellAction = GetComponent<UseSpellAction>();
        baseActionArray = GetComponents<BaseAction>();
        spellUsedAction = GetComponent<SpellUsedAction>();
        animator = GetComponent<Animator>();
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

    public void PlaySpellAnimations(BaseCard baseCard)
    {
        switch (baseCard.cardName)
        {
            case "Fire Ball":
                animator.SetTrigger("Fire Ball");
                break;
            case "Fire Shower":
                animator.SetTrigger("Fire Shower");
                break;
            case "Stone Shower":
                animator.SetTrigger("Stone Shower");
                break;
            case "Freeze":
                animator.SetTrigger("Freeze");
                break;
            case "Water Beam":
                animator.SetTrigger("Water Beam");
                break;
            case "Ice Beam":
                animator.SetTrigger("Ice Beam");
                break;
            case "Lightning":
                animator.SetTrigger("Lightning");
                break;
            case "Moist Shock":
                animator.SetTrigger("Moist Shock");
                break;
        }
 
    }
}
