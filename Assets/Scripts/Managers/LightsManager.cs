using System.Collections;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    [Header("Array of Lights")]
    [SerializeField] private GameObject[] Lights;
    private static LightsManager instance;
    public static LightsManager Instance { get { return instance; } }
    private int randomLight;
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

    public void TurnLightsOff()
    {
        randomLight = Random.Range(0, Lights.Length);
        Lights[randomLight].gameObject.SetActive(false);
        StartCoroutine(CoolDownLights(Lights[randomLight].gameObject));
    }

    IEnumerator CoolDownLights(GameObject Light)
    {
        yield return new WaitForSeconds(5f);
        Light.SetActive(true);
    }
}
