using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private TextMeshProUGUI detectionText, treasureCollected;
    [Header("Game Over")]
    [SerializeField] private GameObject gameOver, nextLevel, gameWon;
    [SerializeField] private Button playAgain, toMainMenu, nextLevelButton, gameWonMainMenu;
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetDetectionText(Detection.UnDetectable);
        gameOver.SetActive(false);
        SetTreasureCollected(TreasureState.NotCollected);
        nextLevel.SetActive(false);
    }

    public void SetGameWon()
    {
        gameWon.SetActive(true);
        gameWonMainMenu.onClick.AddListener(OnToMainMenu);
        Time.timeScale = 0;
    }
    public void SetGameOver()
    {
        gameOver.SetActive(true);
        playAgain.onClick.AddListener(OnPlayAgain);
        toMainMenu.onClick.AddListener(OnToMainMenu);
    }

    public void ToNextLevel()
    {
        nextLevel.SetActive(true);
        nextLevelButton.onClick.AddListener(OnNextLevelButton);
    }

    public void SetTreasureCollected(TreasureState treasureState)
    {
        if (treasureState == TreasureState.NotCollected)
        {
            treasureCollected.text = "Treasure Not Collected";
        }
        else if (treasureState == TreasureState.Collected)
        {
            treasureCollected.text = "Treasure Collected";
        }
    }

    void OnNextLevelButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnPlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE) 
    Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#endif
    }

    void OnToMainMenu()
    {
        Time.timeScale = 1;
        Debug.Log("Main Menu Pressed");
    }

    public void SetDetectionText(Detection detectionType)
    {
        detectionText.text = detectionType.ToString();
    }
}
