using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] public TextMeshPro zombiesKilledText;
    
    public void Setup(int zombiesKilled)
    {
        zombiesKilledText.text = "Zombies Killed: " + zombiesKilled;
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("my_scene");
    }
}
