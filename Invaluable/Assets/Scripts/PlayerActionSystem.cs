using UnityEngine;

public class PlayerActionSystem : MonoBehaviour
{
    public static PlayerActionSystem Instance { private set; get; }

    [SerializeField] private Player player;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more then one instance of PlayerActionSystem!" + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public Player GetPlayer()
    {
        return player;
    }

}
