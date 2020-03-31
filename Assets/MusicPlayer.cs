using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicPlayer : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("LoadFirstLevel", 2f);
    }

    private void LoadFirstLevel() {
        SceneManager.LoadScene(1);
    }
}
