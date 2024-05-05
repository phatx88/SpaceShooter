using UnityEngine;

public class FaceDirection : MonoBehaviour
{
    [SerializeField] private Transform parentTransform; // Optional reference to the parent transform
    [SerializeField] private bool maintainHorizontalDirection = true; // To lock the Y-axis facing up
    [SerializeField] private float rotationSpeed = 15.0f; // Speed in degrees per second for continuous rotation

    void Start()
    {
        if (parentTransform == null)
        {
            parentTransform = transform.parent; // Automatically find the parent if not set
        }

        if (parentTransform == null)
        {
            Debug.LogWarning("Parent Transform not assigned for FaceDirection.");
        }
    }

    void Update()
    {
        if (parentTransform != null)
        {
            // Keep the child object facing the initial direction relative to the world's upward direction
            Vector3 forwardDirection = maintainHorizontalDirection ? Vector3.up : parentTransform.up;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, forwardDirection);
        }

        // Continuously rotate the sprite around its own axis in a clockwise direction
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
