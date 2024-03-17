// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed;

//     void Update()
//     {
//         float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
//         float moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

//         transform.position += new Vector3(moveX, moveY, 0f);
//     }
// }

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1.2f; // The multiplier for the speed when sprinting

    void Update()
    {
        // Check if the Shift key is held down
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        
        // Determine the current move speed based on whether the player is sprinting
        float currentSpeed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;

        // Get movement input
        float moveX = Input.GetAxisRaw("Horizontal") * currentSpeed * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;

        // Apply the movement
        transform.position += new Vector3(moveX, moveY, 0f);
    }
}
