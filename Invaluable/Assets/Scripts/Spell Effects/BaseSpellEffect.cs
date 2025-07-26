using UnityEngine;

public abstract class BaseSpellEffect : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int damageAmount;
    protected Transform targetPosition;

    protected void Awake()
    {
        targetPosition.position = transform.position;
    }

    protected void Update()
    {
        Vector3 moveDirection = (targetPosition.position - transform.position).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            HealthSystem healthSystem = enemy.GetComponent<HealthSystem>();
            healthSystem.TakeDamage(damageAmount, true);


        }
        else if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            HealthSystem healthSystem = player.GetHealthSystem();
            healthSystem.TakeDamage(damageAmount, false);

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
        this.targetPosition.localScale = new Vector3(scale, this.targetPosition.localScale.y, this.targetPosition.localScale.z); 
    }
}
