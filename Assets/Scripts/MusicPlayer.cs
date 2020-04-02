using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    private void Awake() {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if(numMusicPlayers > 1) {
            // print("Number of Music Players in this scence " + numMusicPlayers);
            Destroy(gameObject);
        } 
        
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
}
