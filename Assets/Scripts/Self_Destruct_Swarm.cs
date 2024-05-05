using System.Collections;
using UnityEngine;

public class Self_Destruct_Swarm : MonoBehaviour
{
    public float timer = 50f;
    private DamageController damageController;
    private Coroutine selfDestructCoroutine;
    private SwarmSpawner parentSpawner;

    void Start()
    {
        damageController = GetComponent<DamageController>();

        // Start the coroutine to handle the self-destruct mechanism
        selfDestructCoroutine = StartCoroutine(SelfDestructCoroutine());
    }

    void OnDestroy()
    {
        if (selfDestructCoroutine != null)
        {
            StopCoroutine(selfDestructCoroutine);
        }
    }

    public void SetParentSpawner(SwarmSpawner spawner)
    {
        parentSpawner = spawner;
    }

    public void TriggerSelfDestruct()
    {
        timer = 1f; // Adjust the timer to destroy immediately
        if (selfDestructCoroutine != null)
        {
            StopCoroutine(selfDestructCoroutine);
        }
        selfDestructCoroutine = StartCoroutine(SelfDestructCoroutine());
    }

    private IEnumerator SelfDestructCoroutine()
    {
        yield return new WaitForSeconds(timer);
        StartCoroutine(damageController.Die());
    }
}
