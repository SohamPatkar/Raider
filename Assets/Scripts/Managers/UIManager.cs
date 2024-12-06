using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private TextMeshProUGUI detectionText, treasureCollected;
    [Header("Game Over")]
    [SerializeField] private GameObject gameOver, nextLevel;
    [SerializeField] private Button playAgain, toMainMenu, nextLevelButton;
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
