using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public bool IsControlEnabled { get; private set; }

    [SerializeField] float movementSpeed = 10f;
    [SerializeField] Collider2D confiner;

    readonly int RUNNING_HASH = Animator.StringToHash("Running");
    readonly int IDLE_ANIMATION = Animator.StringToHash("Idle");

    float boundsPadding = .5f;

    Vector2 movement;
    Rigidbody2D rb;
    Animator animator;
    Health health;

    Bounds movementBounds;




    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        IsControlEnabled = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        movementBounds = confiner.bounds;
    }

    void Update()
    {
        if (IsControlEnabled)
        {
            UpdateMovementInput();
            ClampPosition();
            HandleSpriteFlip();
        }
    }

    void OnEnable()
    {
        LevelManager.OnLevelCompleted += DisablePlayerControls;
    }

    void OnDisable()
    {
        LevelManager.OnLevelCompleted -= DisablePlayerControls;
    }

    void DisablePlayerControls()
    {
        IsControlEnabled = false;
    }

    void UpdateMovementInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (!health.isDead)
        {
            HandleMovementAnimation();
            HandleMovement();
        }
    }

    void HandleMovement()
    {
        rb.velocity = movement * movementSpeed;
    }

    void ClampPosition()
    {
        float clampX = Mathf.Clamp(transform.position.x,
        movementBounds.min.x + boundsPadding,
        movementBounds.max.x - boundsPadding);

        float clampY = Mathf.Clamp(transform.position.y,
        movementBounds.min.y + boundsPadding,
        movementBounds.max.y - boundsPadding);

        transform.position = new Vector2(clampX, clampY);
    }

    void HandleSpriteFlip()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void HandleMovementAnimation()
    {
        if (movement != Vector2.zero)
        {
            animator.Play(RUNNING_HASH);
        }
        else
        {
            animator.Play(IDLE_ANIMATION);
        }
    }
}
