using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTrigger : MonoBehaviour
{
    public EyeScript eyeScript;

    //public GameObject Eyeball;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eyeScript.Firing = true;
            //Eyeball.SetActive(true);
        }
    }
}
