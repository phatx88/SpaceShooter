using UnityEngine;
using System.Collections;

public class ScriptActivator : MonoBehaviour
{
    public MonoBehaviour script1;
    public MonoBehaviour script2;
    public float activationDelay = 5f; // Delay before scripts are activated

    void Start()
    {
        // Start the coroutine to activate scripts after a delay
        StartCoroutine(ActivateScriptsAfterDelay());
    }

    IEnumerator ActivateScriptsAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(activationDelay);

        // Enable the scripts
        if (script1 != null)
            script1.enabled = true;

        if (script2 != null)
            script2.enabled = true;
    }
}
