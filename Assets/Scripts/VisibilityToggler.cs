using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VisibilityToggler : MonoBehaviour
{
    // Key to toggle visibility on/off
    [SerializeField] KeyCode toggleKey = KeyCode.Space;

    // Cached reference to the SpriteRenderer on this GameObject
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Toggle on key press
        if (Input.GetKeyDown(toggleKey))
        {
            sr.enabled = !sr.enabled;
        }
    }
}