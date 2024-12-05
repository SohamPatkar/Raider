using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timer;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

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
        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            LightsManager.Instance.TurnLightsOff();
            timer = 0f;
        }
    }

    void InitializeGame()
    {
        timer = 0;
    }

    public void OnDetected()
    {
        UIManager.Instance.SetGameOver();
        Time.timeScale = 0;
    }
}
