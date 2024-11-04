using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 movement;

    void Update()
    {
        // Get input from the player
        movement.x = Input.GetAxis("Horizontal"); // A/D or Left/Right
    }

    void FixedUpdate()
    {
        // Move the player based on input
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime, Space.World);
    }
}

