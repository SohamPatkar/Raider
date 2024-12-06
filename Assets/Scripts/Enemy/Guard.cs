using System.Collections;
using UnityEngine;

public class Guard : Enemy
{
    private void Awake()
    {
        Debug.Log("Awake Called");
        transform.localEulerAngles = Vector3.zero;
    }

    private void Start()
    {
        typeOfEnemy = EnemyType.Guard;
        StartCoroutine(TurnsDelay());
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
