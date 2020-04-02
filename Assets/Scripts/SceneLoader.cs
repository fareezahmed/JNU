using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("LoadFirstLevel", 2f);
    }

    private void LoadFirstLevel() {
        SceneManager.LoadScene(1);
    }
}
