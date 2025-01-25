using UnityEngine;
using System.Collections;

public class movementScriptBoss : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float speed = 5f; // Speed at which the boss follows the player
    public float minimumDistance = 10f; // Minimum distance to maintain from the player
    public float followDelay = 1f; // Delay in seconds before the boss follows the player

    private bool isFollowing = false; // Flag to check if the boss is currently following the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Optionally, find the player by tag if not assigned in the inspector
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !isFollowing)
        {
            // Calculate the distance to the player
            float distance = Vector3.Distance(transform.position, player.position);

            // Start following the player if the distance is greater than the minimum distance
            if (distance > minimumDistance)
            {
                StartCoroutine(FollowPlayerWithDelay());
            }
        }
    }

    private IEnumerator FollowPlayerWithDelay()
    {
        isFollowing = true;
        yield return new WaitForSeconds(followDelay);

        while (Vector3.Distance(transform.position, player.position) > minimumDistance)
        {
            // Calculate the direction to the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the boss towards the player
            transform.position += direction * speed * Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        isFollowing = false;
    }
}
