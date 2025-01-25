using UnityEngine;

public class AIchase : MonoBehaviour
{
    public GameObject character;
    public float speed;

    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position,character.transform.position );
        distance -= 5;
        Vector2 direction = character.transform.position - transform.position;

        direction.Normalize();
        float angle = Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(this.transform.position,character.transform.position,speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.forward * angle);
    }
}
