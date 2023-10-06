using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed;

    public Transform Enemy;
    public Transform Pos1;
    public Transform Pos2;

    public bool movingTo1 = false;
    public bool movingTo2 = true;

    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        if (movingTo1)
        {
            //transform.position = Vector3.MoveTowards(Pos1, Pos2, Speed * Time.deltaTime);
        }
    }
}
