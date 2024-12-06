using UnityEngine;

public class Lights : MonoBehaviour
{

    Player GetPlayerScript(GameObject other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            return other.gameObject.GetComponent<Player>();
        }
        else
        {
            return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player playerScript = GetPlayerScript(other.gameObject);
        if (playerScript != null)
        {
            playerScript.SetDetection(Detection.Detectable);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player playerScript = GetPlayerScript(other.gameObject);
        if (playerScript != null)
        {
            playerScript.SetDetection(Detection.UnDetectable);
        }
    }
}

