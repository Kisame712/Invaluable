using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
public class Enemy : MonoBehaviour
{
    [SerializeField] private List<BaseCard> enemyCards;
    [SerializeField] private int enemyAttacksPerTurn;
    [SerializeField] private Transform spellSpawnPoint;

    private HealthSystem healthSystem;
    private Animator animator;
    public static event EventHandler OnEnemyTurnEnded;

    private void Awake()
    {
        
        healthSystem = GetComponent<HealthSystem>();
        animator = GetComponent<Animator>();
    }

    public void EnemyTurn()
    {
        for(int i = 0; i<enemyAttacksPerTurn; i++)
        {
            BaseCard randomCard =  enemyCards[UnityEngine.Random.Range(0, enemyCards.Count)];
            StartCoroutine(SingleAction(randomCard));
        }
        
    }

    IEnumerator SingleAction(BaseCard baseCard)
    {
        Player player = PlayerActionSystem.Instance.GetPlayer();
        animator.SetTrigger("attack");
        SpellEffectHandler.Instance.PlayLinkedAnimationEffects(baseCard.cardName, spellSpawnPoint, player.transform);
        yield return new WaitForSeconds(1);
    }

}
