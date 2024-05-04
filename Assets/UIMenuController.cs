using UnityEngine;
using UnityEngine.UI;

public class UIMenuController : MonoBehaviour
{
    public Button[] nextLevelButtons;
    public Button[] restartButtons;
    public Button[] menuButtons;

    private AudioManager audioManager;

    void Start()
    {
        // Ensure AudioManager instance is available
        audioManager = AudioManager.Instance;
        SetupButtonListeners();
    }

    private void SetupButtonListeners()
    {
        // Attach click listeners to each button in the arrays
        AttachListenersToButtons(nextLevelButtons, PlayButtonClickSound);
        AttachListenersToButtons(restartButtons, PlayButtonClickSound);
        AttachListenersToButtons(menuButtons, PlayButtonClickSound);
    }

    private void AttachListenersToButtons(Button[] buttons, UnityEngine.Events.UnityAction action)
    {
        foreach (Button button in buttons)
        {
            if (button != null)
            {
                button.onClick.AddListener(action);
            }
        }
    }

    private void PlayButtonClickSound()
    {
        // Play the mouse click sound effect
        if (audioManager != null)
            audioManager.PlaySFX(audioManager.mouseClick);
        else
            Debug.LogError("AudioManager not found!");
    }
}
