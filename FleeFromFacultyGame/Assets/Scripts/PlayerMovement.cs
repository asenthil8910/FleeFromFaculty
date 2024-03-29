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
