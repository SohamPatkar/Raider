using UnityEngine;

public enum TreasureState
{
    Collected,
    NotCollected
}

public class Treasure : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            GameManager.Instance.CoinCollected(gameObject);
            Destroy(gameObject);
        }
    }
}
