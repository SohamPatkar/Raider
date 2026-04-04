using UnityEngine;

public enum Detection
{
    Detectable,
    UnDetectable,
    Detected
}

public class Player : MonoBehaviour
{
    [SerializeField] private Joystick gameController;
    private PlayerAnimations playerAnimations;
    private int score;
    private float movementSpeed;
    private float horizontalMovement, verticalMovement;
    private Vector3 turnLeft, turnRight;
    private Detection canBeDetected;

    void Start()
    {
        if (Global.IsMobile == GameDevice.Mobile)
        {
            gameController.gameObject.SetActive(true);
        }
        else
        {
            gameController.gameObject.SetActive(false);
        }

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
        if (Global.IsMobile != GameDevice.Mobile)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");
        }
        else if (Global.IsMobile == GameDevice.Mobile)
        {
            //for mobile
            horizontalMovement = gameController.Horizontal;
            verticalMovement = gameController.Vertical;
        }

        if (Mathf.Abs(horizontalMovement) > 0.2f)
        {
            verticalMovement = 0;
            playerAnimations.PlayWalking(horizontalMovement);
        }
        else if (Mathf.Abs(verticalMovement) > 0.2f)
        {
            horizontalMovement = 0;
            playerAnimations.PlayWalking(verticalMovement);
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
        UIManager.Instance.SetDetectionText(canBeDetected);
    }
}
