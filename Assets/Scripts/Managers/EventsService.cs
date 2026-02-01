using UnityEngine;
using System;

public class EventsService
{
    public Action<TreasureState> onTreasureCollected;
    public Action<Detection> setDetectionText;
    public Action goToNextLevel;
    public Action gameWonAction;
    public Action gameOverAction;

    public EventsService()
    {

    }
}