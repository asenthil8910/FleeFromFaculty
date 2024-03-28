using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CollisionHandler : MonoBehaviour
{
    public static HashSet<string> collectedKeys = new HashSet<string>();
    public static char doorEntered;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("AI"))
        {
            // Load the GameOver scene
            ResetGame();
            SceneManager.LoadScene("GameOverScene");
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            // Get the unique identifier for the key
            string keyId = collision.gameObject.name; // Use the GameObject's name as the identifier

            // Make the key object disappear
            collision.gameObject.SetActive(false);
            Debug.Log($"Collected key: {keyId}");

            // Register that the player has collected the key
            collectedKeys.Add(keyId);
        }
        else if (collision.gameObject.CompareTag("Door"))
        {
            // Check if the player has the key for this door
            string doorId = collision.gameObject.name; // Use the GameObject's name as the identifier
            string keyId = "Key" + doorId[doorId.Length - 1];
            if (collectedKeys.Contains(keyId))
            {
                // The player has the key, unlock the door
                UnlockDoor(collision.gameObject);
            }
        }
    }

    private void UnlockDoor(GameObject door)
    {
        string doorId = door.name; // Use the GameObject's name as the
        doorEntered = doorId[doorId.Length - 1];
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "GameScene")
        {
            SceneManager.LoadScene("ClassScene" + doorEntered);
        } else
        {
            SceneManager.LoadScene("GameScene");
        } 
    }

    private void ResetGame()
    {
        collectedKeys = new HashSet<string>();
    }
}
