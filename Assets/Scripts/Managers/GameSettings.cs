using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        public float VolumeOfMusic;
        public float VolumeOfSFX;
    }
}