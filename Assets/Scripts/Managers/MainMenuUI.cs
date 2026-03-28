using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private Button playGame, quitGame;
    void Start()
    {
        playGame.onClick.AddListener(OnPlay);
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
