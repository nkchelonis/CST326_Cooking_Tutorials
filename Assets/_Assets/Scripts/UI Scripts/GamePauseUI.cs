using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{

    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button resumeGameButton;
    [SerializeField] private Button optionsButton;

    private void Awake()
    {
        resumeGameButton.onClick.AddListener(() =>
        {
            KitchenGameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenu);
        });
        optionsButton.onClick.AddListener(() =>
        {
            Hide();
            OptionsUI.Instance.Show(Show);
        });
    }
    public void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnOnGamePaused;
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnOnGameUnpaused;

        Hide();
    }

    private void KitchenGameManager_OnOnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void KitchenGameManager_OnOnGamePaused(object sender, EventArgs e)
    {
        Show();
    }


    private void Show()
    {
        gameObject.SetActive(true);
        
        resumeGameButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
