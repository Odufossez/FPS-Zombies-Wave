using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] public Text zombiesKilledText;
    
    public void Setup(int zombiesKilled)
    {
        SceneManager.LoadSceneAsync("GameOver");
        zombiesKilledText.text = "Zombies Killed: " + zombiesKilled;
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        SceneManager.LoadSceneAsync("my_scene");
    }
}
