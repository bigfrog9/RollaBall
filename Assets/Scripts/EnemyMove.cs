using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed;

    private Vector3 StartingPos;

    public Vector3 GoalPos;
    
    public bool movingToStart = false;
    public bool movingToGoal = true;

    // Start is called before the first frame update
    void Start()
    {
        StartingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingToStart)
        {
            //Debug.Log("Moving To Start!");

            transform.position = Vector3.MoveTowards(transform.position, StartingPos, Speed * Time.deltaTime);

            if (transform.position == StartingPos)
            {
                movingToGoal = true;
                movingToStart = false;
            }
        }

        if (movingToGoal)
        {
            //Debug.Log("Moving To Goal!");

            transform.position = Vector3.MoveTowards(transform.position,GoalPos,Speed*Time.deltaTime);

            if(transform.position == GoalPos)
            {
                movingToStart = true;
                movingToGoal = false;
            }
        }
    }
}
