using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;

    // Max offset from the starting position (direction + distance)
    [SerializeField] Vector3 movementVector = new Vector3(3f, 0f, 0f);

    // Seconds for one full back-and-forth cycle
    [SerializeField] float period = 2f;

    // Easing curve: input 0..1  -> output 0..1 (edit in Inspector)
    // Default creates ease-in-out (slow near ends, fast in the middle)
    [SerializeField] AnimationCurve easing = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    void Start()
    {
        // Cache start position so motion is relative to it
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) return;

        // Phase grows with time; PingPong keeps it between 0..1
        float phase01 = Mathf.PingPong(Time.time / period, 1f);

        // Apply easing to get pendulum-like speed profile
        float t = easing.Evaluate(phase01);

        // Move between start and start + movementVector using eased factor
        Vector3 offset = movementVector * t;
        transform.position = startingPosition + offset;
    }
}
