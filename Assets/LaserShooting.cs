using UnityEngine;
using System.Collections;

public class LaserShooting : MonoBehaviour
{
    public GameObject laserBeamPrefab; // Prefab for the laser beam
    public Vector3 laserOffset = new Vector3(0, 0.5f, 0);
    public float laserDuration = 8f; // Total duration of the laser beam effect
    public float scalingDuration = 2f; // Time taken to scale up and down

    private GameObject currentLaserBeam;
    private Transform graphicTransform; // Transform of the GRAPHIC object inside the laser beam prefab

    void OnEnable()
    {
        StartCoroutine(ShootLaserBeam());
    }

    private IEnumerator ShootLaserBeam()
    {
        // Instantiate the laser beam at the specified offset
        Quaternion rotation = transform.rotation;
        Vector3 position = transform.position + rotation * laserOffset;
        currentLaserBeam = Instantiate(laserBeamPrefab, position, rotation, transform);

        // Retrieve the GRAPHIC child object
        graphicTransform = currentLaserBeam.transform.Find("GRAPHIC");

        if (graphicTransform == null)
        {
            Debug.LogWarning("GRAPHIC object not found inside the laser beam prefab.");
        }

        // Play SFX
        AudioControler.Instance.PlaySFX("Laser_Beam");

        // Scale up and down over the duration
        yield return StartCoroutine(ScaleLaserBeam());

        // Destroy the laser beam and disable this script
        Destroy(currentLaserBeam);
        GetComponent<PlayerShooting>().enabled = true;
        enabled = false;
    }

    private IEnumerator ScaleLaserBeam()
    {
        // Scale up phase (1 to 20)
        float elapsedTime = 0f;
        while (elapsedTime < scalingDuration)
        {
            float scaleFactor = Mathf.Lerp(1f, 20f, elapsedTime / scalingDuration);
            graphicTransform.localScale = new Vector3(graphicTransform.localScale.x, scaleFactor, graphicTransform.localScale.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        graphicTransform.localScale = new Vector3(graphicTransform.localScale.x, 20f, graphicTransform.localScale.z);

        // Full size for the remaining duration
        yield return new WaitForSeconds(laserDuration - scalingDuration * 2);

        // Scale down phase (20 to 1)
        elapsedTime = 0f;
        while (elapsedTime < scalingDuration)
        {
            float scaleFactor = Mathf.Lerp(20f, 1f, elapsedTime / scalingDuration);
            graphicTransform.localScale = new Vector3(graphicTransform.localScale.x, scaleFactor, graphicTransform.localScale.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        graphicTransform.localScale = new Vector3(graphicTransform.localScale.x, 1f, graphicTransform.localScale.z);
    }
}
