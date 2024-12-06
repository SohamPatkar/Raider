using UnityEngine;

public enum EnemyType
{
    Orb,
    Guard
}

public class Enemy : MonoBehaviour
{
    public EnemyType typeOfEnemy;
    [Header("Turn Delay")]
    [SerializeField] protected float turnDelay;
    [Header("Places for Movement")]
    [SerializeField] protected Transform placeOne, placeTwo;
    protected Vector3 currentPosition;
    private Vector3 targetLocation, lookLeft, lookRight;
    private void Start()
    {
        lookLeft = new Vector3(-1, 1, 1);
        lookRight = new Vector3(1, 1, 1);
    }

    protected void MovementEnemy(Transform firstPosition, Transform secondPosition, GameObject enemyObject, Vector3 currentPosition)
    {
        if (enemyObject.transform.localPosition.y == secondPosition.transform.localPosition.y)
        {
            targetLocation = firstPosition.transform.localPosition;
        }
        else if (enemyObject.transform.localPosition.y == firstPosition.transform.localPosition.y)
        {
            targetLocation = secondPosition.transform.localPosition;
        }
        else if (enemyObject.transform.localPosition == currentPosition)
        {
            targetLocation = secondPosition.transform.localPosition;
        }
        enemyObject.transform.localPosition = Vector3.MoveTowards(enemyObject.transform.localPosition, targetLocation, 1f * Time.deltaTime);
    }

    public void EnemyTurn(GameObject enemyObject)
    {
        Vector3 currentScale = enemyObject.transform.localScale;

        if (currentScale.x >= 1)
        {
            currentScale.x = -1;
            enemyObject.transform.localScale = currentScale;
        }
        else if (currentScale.x <= -1)
        {
            currentScale.x = 1;
            enemyObject.transform.localScale = currentScale;
        }
    }
}
