using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float chaseDistance = 10f;

    private Vector2 movementDirection;
    private Vector2 nextMovementDirection;
    private float timeToChangeDirection = 0;
    private Rigidbody2D rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PickRandomDirection();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < chaseDistance)
        {
            ChasePlayer();
        }
        else
        {
            Wander();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // When hitting a wall, pick a new random direction
        PickRandomDirection();
    }

    void Wander()
    {
        // Move in the current direction
        rb.velocity = movementDirection * speed;

        // Optionally, gradually change direction for smoother movement
        if (timeToChangeDirection <= 0)
        {
            PickRandomDirection();
            timeToChangeDirection = Random.Range(2, 5); // Change direction every 2 to 5 seconds
        }
        else
        {
            timeToChangeDirection -= Time.deltaTime;
        }
    }

    void ChasePlayer()
    {
        // Calculate the direction to the player and move towards them
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;

        // Calculate the angle to rotate towards
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the enemy's rotation towards the player
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); // Subtracting 90 degrees if your sprite's "forward" is upwards
    }

    void PickRandomDirection()
    {
        // Pick a new random direction to move in
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        movementDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}
