using UnityEngine;

public class Scaler : MonoBehaviour
{
    Vector3 originalScale;

    // How much to scale relative to original size
    [SerializeField] Vector3 scaleAmount = new Vector3(1.2f, 1.2f, 1f);

    // Seconds for one full grow+shrink cycle
    [SerializeField] float period = 2f;

    void Start()
    {
        // Store the object's initial scale
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) return;

        // PingPong gives a 0..1 oscillation over time
        float t = Mathf.PingPong(Time.time / period, 1f);

        // Lerp smoothly between original scale and expanded scale
        transform.localScale = Vector3.Lerp(originalScale, scaleAmount, t);
    }
}