using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject boosterFlame;
    [SerializeField] private float thrustforce = 1f;
    [SerializeField] private float scoreMultiplier = 10f;
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private GameObject explosionEffect;

    Rigidbody2D rb;
    private float elapsedTime = 0f;
    private float score = 0f;
    private Label scoreText;
    private Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();

        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");

        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;  
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Elapsed Time: " + elapsedTime);
        // Debug.Log("Score :"+score);
        UpdateScore();
        MovePlayer();        
    }

    void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime*scoreMultiplier);
        scoreText.text = "Score: "+score;        
    }

    void MovePlayer()
    {
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
        Instantiate(explosionEffect, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex;
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
