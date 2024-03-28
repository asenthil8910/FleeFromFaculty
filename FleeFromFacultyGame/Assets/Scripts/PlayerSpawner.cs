using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Assign this in the Inspector
    public Vector3 spawnPosition = new Vector3(0f, 0f, 0f); // Default spawn position, set this in the Inspector

    void Start()
    {
        char doorEntered = CollisionHandler.doorEntered;
        GameObject door = GameObject.Find("Door" + doorEntered);
        if (door != null)
        {
            // Get the GameObject's position
            spawnPosition = door.transform.position;
            float offset = 1f;
            // offset for entrances
            if (spawnPosition.x < 0f)
            {
                spawnPosition.x += offset;
            } else if (spawnPosition.x > 0f)
            {
                spawnPosition.x -= offset;
            }

            if (spawnPosition.y < 0f)
            {
                spawnPosition.y += offset;
            } else if (spawnPosition.y > 0f)
            {
                spawnPosition.y -= offset;
            }
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
