using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject boosterFlame;
    [SerializeField] private float thrustforce = 1f;
    [SerializeField] private float scoreMultiplier = 10f;

    Rigidbody2D rb;
    private float elapsedTime = 0f;
    private float score = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime*scoreMultiplier);

        Debug.Log("Elapsed Time: " + elapsedTime);
        Debug.Log("Score :"+score);

        if (Mouse.current.leftButton.isPressed)
        {
            // CALCULATE MOUSE DIRECTION
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            // Debug.Log("Mouse position:"+ mousePos);
            
            //MOVE PLAYER IN DIRECTION OF MOUSE
            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction;
            rb.AddForce(direction*thrustforce);
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            boosterFlame.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            boosterFlame.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
