using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float minSize = 0.5f;
    [SerializeField] private float maxSize = 2.0f;

    [SerializeField] private float minSpeed = 50f;
    [SerializeField] private float maxSpeed = 100f;

    [SerializeField] private float maxSpinSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);

        transform.localScale = new Vector3(randomSize, randomSize, 1);

        float randomSpeed = Random.Range(minSpeed, maxSpeed)/randomSize;

        rb = GetComponent<Rigidbody2D>();

        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection*randomSpeed);

        float randomTorque = Random.Range(-maxSpinSpeed,maxSpinSpeed);
        rb.AddTorque(randomTorque);

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
