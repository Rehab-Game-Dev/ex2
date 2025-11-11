using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FitAndFollowBackground2D : MonoBehaviour
{
    [SerializeField] Camera targetCamera;  // if null → Camera.main
    [SerializeField] bool fitOnStart = true;

    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (!targetCamera) targetCamera = Camera.main;
    }

    void Start()
    {
        if (fitOnStart) FitToCameraView();
    }

    void LateUpdate()
    {
        if (!targetCamera) return;
        // Keep background locked to camera center (like a wallpaper)
        transform.position = new Vector3(targetCamera.transform.position.x,targetCamera.transform.position.y,0f);
    }

    void FitToCameraView()
    {
        if (!targetCamera || !sr || !sr.sprite) return;

        // World size of the camera view (orthographic)
        float worldH = targetCamera.orthographicSize * 2f;
        float worldW = worldH * targetCamera.aspect;

        // Sprite size in world units
        Vector2 spriteSize = sr.sprite.bounds.size;

        // Scale so sprite covers the entire view
        float scale = Mathf.Max(worldW / spriteSize.x, worldH / spriteSize.y);
        transform.localScale = new Vector3(scale, scale, 1f);
    }
}