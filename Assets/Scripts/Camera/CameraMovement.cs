using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject player;
    private Vector3 offsetCamera = new Vector3(0, 0, -10);
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offsetCamera;
    }
}
