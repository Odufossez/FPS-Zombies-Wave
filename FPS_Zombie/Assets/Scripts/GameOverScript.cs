using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI zombiesKilledText;
    
    public void Setup(int zombiesKilled)
    {
        Debug.Log("Setting up Game Over Screen");
        zombiesKilledText = GameObject.Find("ZombiesKilledText").GetComponent<TextMeshProUGUI>();
        if (zombiesKilledText == null)
        {
            Debug.Log("Text Mesh Pro not found ");
        }
        zombiesKilledText.text = "Zombies Killed: " + zombiesKilled;
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("my_scene");
    }
}
