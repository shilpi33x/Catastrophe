using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneLetter : MonoBehaviour
{
    [SerializeField] int xPosCoefficient = 1;
    [SerializeField] int yPosCoefficient = 1;
    [SerializeField] int rotationCoefficient = 1;

    [SerializeField] float rotateAmount = 10;
    [SerializeField] float moveAmount = 10;

    [Range(0,10)] [SerializeField] float moveInterval = 1;

    void Start()
    {
        StartCoroutine(MoveLetters());
    }

    private IEnumerator MoveLetters()
    {
        var choice = Random.Range(0,3);

        if(choice == 0)
        {
            transform.position = new Vector2(transform.position.x + (moveAmount * xPosCoefficient), transform.position.y);
            xPosCoefficient = -xPosCoefficient;
        }
        else if(choice == 1)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (moveAmount * yPosCoefficient));
            yPosCoefficient = -yPosCoefficient;
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, (rotateAmount * rotationCoefficient)));
            rotationCoefficient = -rotationCoefficient;
        }
        
        yield return new WaitForSeconds(moveInterval);
        StartCoroutine(MoveLetters());
    }
}
