using System;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI upKey;
    [SerializeField] private TextMeshProUGUI downKey;
    [SerializeField] private TextMeshProUGUI rightKey;
    [SerializeField] private TextMeshProUGUI leftKey;
    [SerializeField] private TextMeshProUGUI interactKey;
    [SerializeField] private TextMeshProUGUI interactAltKey;
    [SerializeField] private TextMeshProUGUI pauseKey;
    
    [SerializeField] private TextMeshProUGUI gamepadInteractKey;
    [SerializeField] private TextMeshProUGUI gamepadInteractAltKey;
    [SerializeField] private TextMeshProUGUI gamepadPauseKey;

    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnOnBindingRebind;
        KitchenGameManager.Instance.OnStateChanged += GameInput_OnOnStateChanged;
        UpdateVisual();
        Show();
    }

    private void GameInput_OnOnStateChanged(object sender, EventArgs e)
    {
        if (KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnOnBindingRebind(object sender, EventArgs e)
    {
        UpdateVisual();
    }


    private void UpdateVisual()
    {
        upKey.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveUp);
        downKey.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveDown);
        leftKey.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveLeft);
        rightKey.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveRight);
        interactKey.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        interactAltKey.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        pauseKey.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
        gamepadInteractKey.text = GameInput.Instance.GetBindingText(GameInput.Binding.GamepadInteract);
        gamepadInteractAltKey.text = GameInput.Instance.GetBindingText(GameInput.Binding.GamepadInteractAlternate);
        gamepadPauseKey.text = GameInput.Instance.GetBindingText(GameInput.Binding.GamepadPause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
    
}
