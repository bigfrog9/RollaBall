using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeUntrigger : MonoBehaviour
{
    public EyeScript eyeScript;

    public EyeScript eye2Script;

    public EnemyMove Enemy1;
    public EnemyMove Enemy2;
    public EnemyMove Enemy3;
    public EnemyMove Enemy4;
    public EnemyMove Enemy5;
    public EnemyMove Enemy6;

    //public GameObject Eyeball;

    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eyeScript.Firing = false;
            eye2Script.Firing = false;

            Enemy1.chasingPlayer = true;
            Enemy2.chasingPlayer = true;
            Enemy3.chasingPlayer = true;
            Enemy4.chasingPlayer = true;
            Enemy5.chasingPlayer = true;
            Enemy6.chasingPlayer = true;

            //Eyeball.SetActive(true);
        }
    }
}
