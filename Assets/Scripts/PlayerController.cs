using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 initialPosition;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private float jumpForce;
    private Animator animator;
    private Rigidbody2D rb;
    private GameManager gameManager;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = GameManager.instance;
        initialPosition = transform.position;
    }


    public void StartPlayer()
    {
        rb.simulated = true;
        animator.enabled = true;
        rb.freezeRotation = false;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (gameManager.IsGameActive == false)
        {
            gameManager.StartGame();
        }
        rb.linearVelocity = Vector2.up * jumpForce;
    }

    public void GameOver()
    {
        animator.enabled = false;
        jumpAction.action.performed -= Jump;
        gameManager.GameOver();

    }

    public void RestartPlayerController()
    {
        transform.rotation = Quaternion.identity;
        rb.freezeRotation = true;
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;
        jumpAction.action.performed += Jump;
        transform.position = initialPosition;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            gameManager.AddScore();
        }
    }
}
