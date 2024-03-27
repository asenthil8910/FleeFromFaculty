using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("AI"))
        {
            // Load the GameOver scene
            SceneManager.LoadScene("GameOverScene");
        }
    }


}
