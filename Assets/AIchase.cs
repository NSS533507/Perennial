using UnityEngine;

public class AIchase : MonoBehaviour
{
    public GameObject character;
    public float speed;
    public float stopDistance = 3.0f; // Minimum distance to stop chasing

    private float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, character.transform.position);

        if (distance > stopDistance)
        {
            Vector2 direction = character.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.position = Vector2.MoveTowards(transform.position, character.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
