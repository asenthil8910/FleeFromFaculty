
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class DraggableRectangle : MonoBehaviour
{
    private Vector3 offset;
    private float zCoordinate;
    private Rigidbody2D rb;
    public bool isColliding = false;
    //public bool didCollide = false;

    public bool isVertical = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (didCollide == false) { 
            isColliding = true;
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
        //didCollide = false;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Ensure Rigidbody2D is set to Kinematic.
    }

    private void OnMouseDown()
    {
        zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        if (isColliding) {
            Debug.LogError("This is colliding");
            //didCollide = true;
            return;
        };
        Vector3 newPosition = GetMouseWorldPos() + offset;
        
        // Check which axis is longer and update only that axis.
        //if (transform.localScale.x > transform.localScale.y)
        if (!isVertical)
        {
            // Move along x-axis
            rb.MovePosition(new Vector2(newPosition.x, rb.position.y));
        }
        else
        {
            // Move along y-axis
            rb.MovePosition(new Vector2(rb.position.x, newPosition.y));
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoordinate;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}


// using UnityEngine;

// [RequireComponent(typeof(BoxCollider2D))]
// public class DraggableRectangle : MonoBehaviour
// {
//     private Vector3 offset;
//     private float zCoordinate;
//     private Vector3 originalPosition;

//     private void OnMouseDown()
//     {
//         // Store the z-coordinate of the game object
//         zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        
//         // Get the original position of the game object
//         originalPosition = transform.position;
        
//         // Compute the offset based on the current mouse position
//         offset = gameObject.transform.position - GetMouseWorldPos();
//     }

//     private void OnMouseDrag()
//     {
//         // Get the new position based on the mouse position plus the stored offset
//         Vector3 newPosition = GetMouseWorldPos() + offset;

//         // Constrain the movement along the longer axis
//         if (transform.localScale.x > transform.localScale.y) // Rectangle is longer in the x-direction
//         {
//             // Keep the y position constant
//             newPosition.y = originalPosition.y;
//         }
//         else // Rectangle is longer in the y-direction
//         {
//             // Keep the x position constant
//             newPosition.x = originalPosition.x;
//         }

//         // Update the position of the game object
//         transform.position = new Vector3(newPosition.x, newPosition.y, originalPosition.z);
//     }

//     // Convert mouse position to world coordinates
//     private Vector3 GetMouseWorldPos()
//     {
//         Vector3 mousePoint = Input.mousePosition;
        
//         // Set the mousePoint z-coordinate to the stored z-coordinate of the game object
//         mousePoint.z = zCoordinate;
        
//         // Convert the mouse position to world space
//         return Camera.main.ScreenToWorldPoint(mousePoint);
//     }
// }