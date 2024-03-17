using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        transform.position += new Vector3(moveX, moveY, 0f);
    }
}
