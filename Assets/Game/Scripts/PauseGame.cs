using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] EscMenuUI escMenuUI;
    [HideInInspector] public Overlay owner;
    public PlayerInput playerInput;
    bool onPause = false;
    float oldTimeScale = 1f;

    public void Initialize()
    {
        escMenuUI.OnContinueButtonPressed.AddListener(Pause);
        escMenuUI.OnCryCravenButtonPressed.AddListener(Pause);
    }

    public void KeyPressed(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Pause();
        }
    }
    private void Pause()
    {
        if (onPause)
        {
            if (escMenuUI.Close())
            {
                Time.timeScale = oldTimeScale;
                onPause = false;
                playerInput.enabled=true;
            }
        }
        else
        {
            if (escMenuUI.Open())
            {
                playerInput.enabled=false;
                oldTimeScale = Time.timeScale;
                Time.timeScale = 0f;
                onPause = true;
            }
        }
    }
}
