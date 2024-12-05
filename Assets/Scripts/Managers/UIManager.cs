using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private TextMeshProUGUI detectionText;
    [Header("Game Over")]
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Button playAgain, toMainMenu;
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
    }

    public void SetGameOver()
    {
        gameOver.SetActive(true);
        playAgain.onClick.AddListener(OnPlayAgain);
        toMainMenu.onClick.AddListener(OnToMainMenu);
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
