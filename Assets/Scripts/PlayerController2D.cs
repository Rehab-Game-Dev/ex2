using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    [SerializeField] float speed = 6f;     // Movement speed in units per second
    Rigidbody2D rb;

    void Awake()
    {
        // Cache Rigidbody2D and prevent rotation caused by physics or parent rotation
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Get input from arrow keys or WASD
        float x = Input.GetAxisRaw("Horizontal"); // Left / Right (-1 to +1)
        float y = Input.GetAxisRaw("Vertical");   // Up / Down (-1 to +1)

        // Move in world space only (not affected by camera or parent rotation)
        rb.linearVelocity = new Vector2(x * speed, y * speed);
    }
}
