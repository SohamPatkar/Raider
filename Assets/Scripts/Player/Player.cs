using UnityEngine;
using UnityEngine.InputSystem;

public enum Detection
{
    Detectable,
    UnDetectable,
    Detected
}

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionReference gameController;
    [SerializeField] private GameObject mobileController;
    private int score;
    private float movementSpeed;
    private float horizontalMovement, verticalMovement;
    private Vector3 turnLeft, turnRight;
    private Detection canBeDetected;
    private PlayerAnimations playerAnim;

    void Start()
    {
        playerAnim = new PlayerAnimations(GetComponent<Animator>());

        if (Global.IsMobile == GameDevice.Mobile)
        {
            mobileController.SetActive(true);
        }
        else
        {
            mobileController.SetActive(false);
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
            horizontalMovement = gameController.action.ReadValue<Vector2>().x;
            verticalMovement = gameController.action.ReadValue<Vector2>().y;
        }

        transform.position += new Vector3(horizontalMovement * movementSpeed * Time.deltaTime, verticalMovement * movementSpeed * Time.deltaTime, 0);
        playerAnim.PlayWalking(horizontalMovement);

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
