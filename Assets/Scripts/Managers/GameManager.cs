using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Treasure")]
    [SerializeField] private List<GameObject> Treasure = new List<GameObject>();
    private bool isTreasureCollected;
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
        isTreasureCollected = false;
    }

    public void CoinCollected(GameObject gameObject)
    {
        Treasure.Remove(gameObject);
        if (Treasure.Count == 0)
        {
            UIManager.Instance.SetTreasureCollected(TreasureState.Collected);
            isTreasureCollected = true;
        }
    }

    public void EndGame()
    {
        if (isTreasureCollected)
        {
            UIManager.Instance.ToNextLevel();
            Time.timeScale = 0;
        }
        else
        {
            UIManager.Instance.SetTreasureCollected(TreasureState.NotCollected);
        }
    }

    public void OnDetected()
    {
        UIManager.Instance.SetGameOver();
        Time.timeScale = 0;
    }
}
