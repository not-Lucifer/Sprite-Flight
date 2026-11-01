using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;
    float minSize = 0.5f;
    float maxSize = 2.0f;

    float minSpeed = 50f;
    float maxSpeed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        rb = GetComponent<Rigidbody2D>();

        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection*randomSpeed);

        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
