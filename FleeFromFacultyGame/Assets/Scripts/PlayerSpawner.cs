using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Assign this in the Inspector
    public Vector3 spawnPosition; // Default spawn position, set this in the Inspector

    void Start()
    {
        // deactivating all collected keys in the current room upon spawning
        foreach (string key in CollisionHandler.collectedKeys)
        {
            GameObject keyObject = GameObject.Find("Key" + key[key.Length - 1]); 
            if (keyObject != null)
            {
                keyObject.SetActive(false);
            }
        }
        char doorEntered = CollisionHandler.doorEntered;
        GameObject door = GameObject.Find("Door" + doorEntered);
        if (door != null)
        {
            // Get the GameObject's position
            spawnPosition = door.transform.position;
            float offset = 1f;
        
            spawnPosition = door.transform.position + (door.transform.right * offset);
            // Now you have the coordinates in the position variable
            Debug.Log("The position of the GameObject is: " + spawnPosition);
        }
        else
        {
            Debug.Log("GameObject not found!");
        }
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        if(playerPrefab != null)
        {
            // Instantiate the player prefab at the spawn position with no rotation
            playerPrefab.transform.position = spawnPosition;
        }
        else
        {
            Debug.LogError("PlayerSpawner: Player Prefab is not assigned.");
        }
    }
}
