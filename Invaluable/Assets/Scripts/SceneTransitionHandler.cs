using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionHandler : MonoBehaviour
{
    [SerializeField] private GameObject enemyDefeatedBanner;
    [SerializeField] private GameObject bloodEffect;
    [SerializeField] private GameObject playerActionsUI;
    [SerializeField] private GameObject buySpellsButton;
    [SerializeField] private GameObject nextTurnButton;
    [SerializeField] private GameObject timeSlotText;
    [SerializeField] private GameObject timeSlotIcon;
    public static SceneTransitionHandler Instance { private set; get; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of SceneTransitionHandler" + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SceneExit(Transform spawnPosition, GameObject gameObject1)
    {
        
        StartCoroutine(DisplayVictoryBanner(spawnPosition, gameObject1));
    }

    IEnumerator DisplayVictoryBanner(Transform spawnPosition, GameObject gameObject1)
    {
        enemyDefeatedBanner.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bloodEffect, spawnPosition.position, Quaternion.identity);
        Destroy(gameObject1);
        playerActionsUI.SetActive(false);
        buySpellsButton.SetActive(false);
        nextTurnButton.SetActive(false);
        timeSlotIcon.SetActive(false);
        timeSlotText.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
