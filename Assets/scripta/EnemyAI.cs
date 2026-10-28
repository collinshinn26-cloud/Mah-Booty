using UnityEngine;

public class EnemyAI : MonoBehaviour

{
    public float speed = 2.0f; // Movement speed
    private Transform playerTransform; // Reference to the player's position

    void Start()
    {
        // Automatically find the player object using the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Move toward the player's position
            Vector2 targetPosition = new Vector2(playerTransform.position.x, transform.position.y); // Use transform.position.y for top-down
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
