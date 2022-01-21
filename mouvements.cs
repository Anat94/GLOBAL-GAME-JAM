using UnityEngine;

public class mouvements : MonoBehaviour
{
    public CharacterController playerController;

    Vector3 velocity;
    public float speed = 5f;
    private float gravity = -9.81f;

    void Update() {
        Mouvement();
    }

    public void Mouvement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        playerController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}