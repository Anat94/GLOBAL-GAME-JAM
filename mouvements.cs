using UnityEngine;

public class mouvements : MonoBehaviour
{
    public CharacterController playerController;
    Vector3 velocity;
    bool isGrounded;

    public float speed = 5f;
    private float gravity = -9.81f;

    private int jumpCount = 0;
    public int jumpMax = 1;
    public int jumpHeight = 3;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;


    void Start() {
        Debug.Log(jumpCount);
        Debug.Log(jumpMax);
    }

    void Update()
    {
        GroundReset();
        Mouvement();
        Jump();
    }

    public void Mouvement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        playerController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount != jumpMax)
        {
            jumpCount += 1;
            velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2f);
            Debug.Log(jumpCount);
        }
    }

    public void GroundReset()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
        if (isGrounded) {
            jumpCount = 0;
        }
    }
}