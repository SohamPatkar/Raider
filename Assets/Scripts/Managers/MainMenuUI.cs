using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : UIManager
{
    [Header("Main Menu")]
    [SerializeField] private Button playGame, quitGame;
    void Start()
    {
        playGame.onClick.AddListener(OnPlay);
        quitGame.onClick.AddListener(OnQuit);
    }
}
