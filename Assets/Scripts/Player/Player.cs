using UnityEngine;

public enum Detection
{
    Detectable,
    UnDetectable,
    Detected
}

public class Player : MonoBehaviour
{
    private PlayerAnimations playerAnimations;
    private int score;
    private float movementSpeed;
    private float horizontalMovement, verticalMovement;
    private Vector3 turnLeft, turnRight;
    private Detection canBeDetected;
    private void Awake()
    {
        InitializePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void InitializePlayer()
    {
        turnLeft = new Vector3(0, 180, 0);
        turnRight = new Vector3(0, 0, 0);
        playerAnimations = GetComponent<PlayerAnimations>();
        canBeDetected = Detection.UnDetectable;
        score = 0;
        movementSpeed = 1.5f;
    }

    void Movement()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if (horizontalMovement != 0)
        {
            playerAnimations.PlayWalking(horizontalMovement);
            verticalMovement = 0;
        }
        else if (verticalMovement != 0)
        {
            playerAnimations.PlayWalking(verticalMovement);
            horizontalMovement = 0;
        }

        transform.position += new Vector3(horizontalMovement * movementSpeed * Time.deltaTime, verticalMovement * movementSpeed * Time.deltaTime, 0);

        TurnPlayer();
    }

    void TurnPlayer()
    {
        if (horizontalMovement < 0)
        {
            transform.localEulerAngles = turnLeft;
        }
        else if (horizontalMovement > 0)
        {
            transform.localEulerAngles = turnRight;
        }
    }

    public void SetScore(int scoreToadd)
    {
        score = scoreToadd;
    }

    public Detection ReturnDetection()
    {
        return canBeDetected;
    }

    public void SetDetection(Detection detection)
    {
        canBeDetected = detection;
    }
}
