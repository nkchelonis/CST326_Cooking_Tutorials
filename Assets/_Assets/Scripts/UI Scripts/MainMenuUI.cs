using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    
    
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            //play the game
            Loader.Load(Loader.Scene.KitchenTime);
        });
        quitButton.onClick.AddListener(() =>
        {
            //quit the game
            Application.Quit();
        });
        
        Time.timeScale = 1f;
    }

    
}
