using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private Button playGame, quitGame;
    [SerializeField] private Button settingsButton;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    void Start()
    {
        playGame.onClick.AddListener(OnPlay);

        settingsButton.onClick.AddListener(() => {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        });
        
        quitGame.onClick.AddListener(OnQuit);
    }

    private void OnPlay()
    {
        SceneManager.LoadScene("Level1");
    }

    private void OnQuit()
    {
        
    }
}
