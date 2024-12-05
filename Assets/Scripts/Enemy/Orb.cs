using UnityEngine;

public class Orb : Enemy
{
    private void Awake()
    {
        typeOfEnemy = EnemyType.Orb;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = gameObject.transform.localPosition;
    }

    void Update()
    {
        MovementEnemy(placeTwo, placeOne, gameObject, currentPosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            playerScript.SetDetection(Detection.Detected);
            UIManager.Instance.SetDetectionText(playerScript.ReturnDetection());
            GameManager.Instance.OnDetected();
        }
    }
}
