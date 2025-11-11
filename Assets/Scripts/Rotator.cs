using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Rotation speed in degrees per second
    [SerializeField] float rotationSpeed = 90f;

    void Update()
    {
        // Rotate around the Z axis
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
