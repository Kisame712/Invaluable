using UnityEngine;

public class BaseSpellEffect : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int damageAmount;
    [SerializeField] private GameObject bloodEffect;
    protected Transform targetPosition;

    protected void Update()
    {
        Vector3 moveDirection = (targetPosition.position - transform.position).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(bloodEffect, collision.transform.position, Quaternion.identity);
            Enemy enemy = collision.GetComponent<Enemy>();
            HealthSystem healthSystem = enemy.GetComponent<HealthSystem>();
            healthSystem.TakeDamage(damageAmount, true);
            Animator cameraAnim = Camera.main.GetComponent<Animator>();
            cameraAnim.SetTrigger("shake");


        }
        else if (collision.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(bloodEffect, collision.transform.position, Quaternion.identity);
            Player player = collision.GetComponent<Player>();
            HealthSystem healthSystem = player.GetHealthSystem();
            healthSystem.TakeDamage(damageAmount, false);
            Animator cameraAnim = Camera.main.GetComponent<Animator>();
            cameraAnim.SetTrigger("shake");

        }
    }

    public virtual void SetTargetPosition(Transform targetPosition)
    {
        int scale = 1;
        Player player = PlayerActionSystem.Instance.GetPlayer();

        if(targetPosition == player.transform)
        {
            scale = -1;
        }
        this.targetPosition = targetPosition;
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z); 
    }
}
