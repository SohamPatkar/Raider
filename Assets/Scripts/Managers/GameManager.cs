using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Services;

public class GameManager : SingleTonManager<GameManager>
{
    [Header("Treasure")]
    [SerializeField] private List<GameObject> Treasure = new List<GameObject>();
    [SerializeField] private UIManager refToUIManager;
    private bool isTreasureCollected;
    private float timer;
    private EventsService eventsService;
    
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
        Global.Init();

        timer = 0;
        isTreasureCollected = false;
        eventsService = new EventsService();

        refToUIManager.Initialization();

        eventsService.setGameDeviceText?.Invoke(Global.IsMobile.ToString());
    }

    public EventsService GetEventService()
    {
        return eventsService;
    }

    public void CoinCollected(GameObject gameObject)
    {
        Treasure.Remove(gameObject);

        if (Treasure.Count == 0)
        {
            GetEventService().onTreasureCollected.Invoke(TreasureState.Collected);
            isTreasureCollected = true;
        }
    }

    public void EndGame()
    {
        if (isTreasureCollected && SceneManager.GetActiveScene().buildIndex == 1)
        {
            eventsService.goToNextLevel.Invoke();
            Time.timeScale = 0;
        }
        else if (isTreasureCollected && SceneManager.GetActiveScene().buildIndex == 2)
        {
            eventsService.gameWonAction.Invoke();
        }
        else
        {
            eventsService.onTreasureCollected.Invoke(TreasureState.NotCollected);
        }
    }

    public void OnDetected()
    {
        eventsService.gameOverAction.Invoke();
        Time.timeScale = 0;
    }
}
