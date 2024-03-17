using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AI"))
        {
            // Load the GameOver scene
            Debug.Log("fuckin shit");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
