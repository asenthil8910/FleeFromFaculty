// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     public float sprintMultiplier = 1.2f; // The multiplier for the speed when sprinting

//     void Update()
//     {
//         // Check if the Shift key is held down
//         bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        
//         // Determine the current move speed based on whether the player is sprinting
//         float currentSpeed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;

//         // Get movement input
//         float moveX = Input.GetAxisRaw("Horizontal") * currentSpeed * Time.deltaTime;
//         float moveY = Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;

//         // Apply the movement
//         transform.position += new Vector3(moveX, moveY, 0f);
//     }
// }



// using UnityEngine;
// using UnityEngine.UI;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     public float sprintMultiplier = 1.2f; // The multiplier for the speed when sprinting
//     public Slider staminaBar; // Assign this in the Unity Inspector

//     // Stamina variables
//     public float maxStamina = 100f;
//     private float currentStamina;
//     public float sprintStaminaCost = 10f; // Stamina cost per second of sprinting
//     public float staminaRegenRate = 20f; // Stamina regeneration per second when not sprinting
//     public float minStaminaToSprint = 10f; // Minimum stamina required to start sprinting

//     private bool canSprint = true;

//     void Start()
//     {
//         currentStamina = maxStamina; // Initialize stamina
//     }

//     void Update()
//     {
//         Debug.LogError(currentStamina);
//         // Check if there's enough stamina to sprint
//         bool isTryingToSprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
//         bool isSprinting = isTryingToSprint && canSprint && currentStamina > 0;

//         // Determine the current move speed based on whether the player is sprinting
//         float currentSpeed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;

//         // Handle stamina reduction or regeneration
//         if (isSprinting)
//         {
//             currentStamina -= sprintStaminaCost * Time.deltaTime; // Reduce stamina
//         }
//         else
//         {
//             currentStamina += staminaRegenRate * Time.deltaTime; // Regenerate stamina
//         }

//         // Update canSprint status
//         if (currentStamina < minStaminaToSprint)
//         {
//             canSprint = false;
//         }
//         else if (currentStamina >= minStaminaToSprint && !isTryingToSprint)
//         {
//             canSprint = true; // Allow sprinting again once stamina is above the threshold and the player is not trying to sprint
//         }

//         // Clamp the currentStamina to ensure it stays within bounds
//         currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

//         // Update the stamina bar UI
//         if (staminaBar != null)
//         {
//             staminaBar.value = currentStamina / maxStamina;
//         }

//         // Get movement input
//         float moveX = Input.GetAxisRaw("Horizontal") * currentSpeed * Time.deltaTime;
//         float moveY = Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;

//         // Apply the movement
//         transform.position += new Vector3(moveX, moveY, 0f);
//     }
// }

using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1.2f; // The multiplier for the speed when sprinting
    public Slider staminaBar; // Assign this in the Unity Inspector

    // Stamina variables
    public float maxStamina = 50f;
    private float currentStamina;
    public float sprintStaminaCost = 15f; // Stamina cost per second of sprinting
    public float staminaRegenRate = 10f; // Stamina regeneration per second when not sprinting
    public float minStaminaToSprint = 2f; // Minimum stamina required to be unable to sprint

    private bool canSprint = true;

    void Start()
    {
        currentStamina = maxStamina; // Initialize stamina
    }

    void Update()
    {
        Debug.LogError(currentStamina);
        bool isTryingToSprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isSprinting = isTryingToSprint && canSprint && currentStamina > minStaminaToSprint;

        float currentSpeed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;

        if (isSprinting)
        {
            currentStamina -= sprintStaminaCost * Time.deltaTime;
        }
        else
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
        }

        // Update canSprint status based on current stamina
        if (currentStamina < minStaminaToSprint)
        {
            canSprint = false; // Disable sprinting if stamina drops below the threshold
        }
        else if (currentStamina >= maxStamina)
        {
            canSprint = true; // Only allow sprinting again once stamina fully recovers
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        if (staminaBar != null)
        {
            staminaBar.value = currentStamina / maxStamina;
        }

        // Apply the movement
        float moveX = Input.GetAxisRaw("Horizontal") * currentSpeed * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;
        transform.position += new Vector3(moveX, moveY, 0f);
    }
}
