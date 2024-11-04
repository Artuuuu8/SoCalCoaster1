using System.Collections;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed = 5f;              // Initial speed of ground 
    public float acceleration = 0.1f;      // How fast speed increases over time
    public float maxSpeed = 50f;           // Maximum speed to limit how fast ground can move
    public float groundLength = 50f;       // Length of object

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the ground backward along the Z axis
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Check if the ground has moved enough to loop
        if (transform.position.z < startPosition.z - groundLength)
        {
            transform.position += new Vector3(0, 0, groundLength * 2); // Move back to front
        }

        // Increase the speed over time for a constant speed increase effect
        speed += acceleration * Time.deltaTime;

        // Ensure the speed doesn't exceed a maximum value
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}