using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In Seconds")][SerializeField] float loadLevelDelay = 1f;
    [Tooltip("FX effects Prefab on player")][SerializeField] GameObject deathFX;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();   
    }

    void StartDeathSequence() 
    {   
        // print("Player Dying");
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadScene", loadLevelDelay); 
    }

    void ReloadScene() // String reference to method
    {
        SceneManager.LoadScene(1);
    }
}
