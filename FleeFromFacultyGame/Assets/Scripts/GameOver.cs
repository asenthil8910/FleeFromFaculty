using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Required for scene management

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; // Assign in the Inspector
    public AudioClip winSound; // Assign in the Inspector
    public AudioClip loseSound; // Assign in the Inspector

    private AudioSource audio;

    void Start()
    {
        if (CollisionHandler.gameWon)
        {
            gameOverText.text = "You Escaped the School!";
            audio.PlayOneShot(winSound);
        }
        else
        {
            gameOverText.text = "You have been caught";
            audio.PlayOneShot(loseSound);
        }
    }
}