using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    public Camera mainCamera;
    public float buffer = 1.0f;  // You can adjust this buffer to ensure no gaps are visible

    void Update()
    {
        float camHeight = mainCamera.orthographicSize * 2;
        float camWidth = camHeight * mainCamera.aspect;
        transform.localScale = new Vector3(camWidth * buffer, camHeight * buffer, 1);
        transform.localPosition = new Vector3(0, 0, 10);  // Adjust the Z to ensure it's behind all other objects
    }
}
