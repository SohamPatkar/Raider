using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Orb,
    Guard
}

public class Enemy : MonoBehaviour
{
    public EnemyType typeOfEnemy;
    [SerializeField] protected Transform placeOne, placeTwo;
    protected Vector3 currentPosition;
    private Vector3 targetLocation, lookLeft, lookRight;
    private void Start()
    {
        targetLocation = placeTwo.localPosition;
        lookLeft = new Vector3(0, 180, 0);
        lookRight = new Vector3(0, 180, 0);
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
        enemyObject.transform.localEulerAngles = lookLeft;

    }

    IEnumerator LookAfter()
    {
        yield return new WaitForSeconds(3f);

    }
}
