using System.Collections;
using UnityEngine;

public class Guard : Enemy
{
    [SerializeField] private SpriteRenderer guardSprite;

    private void Awake()
    {
        if (guardSprite.sprite == null)
        {
            Debug.LogError("Guard sprite not assigned in the inspector.");

        }
        Debug.Log("Awake Called");
        transform.localEulerAngles = Vector3.zero;
    }

    private void Start()
    {
        if (guardSprite.sprite == null)
        {
            Debug.LogError("Guard sprite not assigned in the inspector.");

        }
        typeOfEnemy = EnemyType.Guard;
        StartCoroutine(TurnsDelay());
    }

    void Update()
    {
        if (guardSprite.sprite == null)
        {
            Debug.LogError("Guard sprite not assigned in the inspector.");

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript.ReturnDetection() == Detection.Detectable)
            {
                SoundManager.Instance.PlaySfx(SoundType.Detected);
                playerScript.SetDetection(Detection.Detected);
                GameManager.Instance.OnDetected();
            }
        }
    }

    IEnumerator TurnsDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(turnDelay);
            EnemyTurn(gameObject);
        }
    }
}
