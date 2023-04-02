using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCon : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private PlayerInput playerInput;
    public new Rigidbody2D rigidbody { get; private set; }


    public float thrustSpeed = 1f;
    public bool thrusting;

    public float turnDirection { get; private set; } = 0f;
    public float rotationSpeed = 0.1f;

    public float respawnDelay = 3f;
    public float respawnInvulnerability = 3f;

    private InputAction ForwardMoveAction;
    private InputAction RightMoveAction;
    private InputAction LeftMoveAction;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ForwardMoveAction = playerInput.actions["MoveForward"];
        RightMoveAction = playerInput.actions["MoveRight"];
        LeftMoveAction = playerInput.actions["MoveLeft"];

    }


    private void Update()
    {
        if (thrusting)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsIdle", false);
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsIdle", true);
        }
    }



    private void OnEnable()
    {

        ForwardMoveAction.performed += _ => ForwardStart();
        ForwardMoveAction.canceled += _ => ForwardStop();

        RightMoveAction.performed += _ => RightStart();
        RightMoveAction.canceled += _ => RightStop();

        LeftMoveAction.performed += _ => LeftStart();
        LeftMoveAction.canceled += _ => LeftStop();


    }
    private void OnDisable()
    {

        ForwardMoveAction.performed -= _ => ForwardStart();
        ForwardMoveAction.canceled -= _ => ForwardStop();

        ForwardMoveAction.performed -= _ => RightStart();
        ForwardMoveAction.canceled -= _ => RightStop();

        LeftMoveAction.performed -= _ => LeftStart();
        LeftMoveAction.canceled -= _ => LeftStop();



    }

    void ForwardStart()
    {
        thrusting = true;

    }
    void ForwardStop()
    {
        thrusting = false;
    }

    void RightStart()
    {
        turnDirection = -1f;
    }

    void RightStop()
    {
        turnDirection = 0f;
    }

    void LeftStart()
    {
        turnDirection = 1f;
    }

    void LeftStop()
    {
        turnDirection = 0f;
    }





    private void FixedUpdate()
    {
        //Movement inputs for forward and side movements
        if (thrusting)
        {
            rigidbody.AddForce(transform.up * thrustSpeed);
        }

        if (turnDirection != 0f)
        {
            rigidbody.AddTorque(rotationSpeed * turnDirection);
        }
    }





    void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision Funcnction for when the player collides with Worm Objects
        if (collision.gameObject.CompareTag("Worm"))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0f;
            gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDeath(this);
        }
    }
}

