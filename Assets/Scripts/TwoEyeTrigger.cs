using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoEyeTrigger : MonoBehaviour
{
    public EyeScript eyeScript;

    public EyeScript eye2Script;

    //public GameObject Eyeball;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eyeScript.Firing = true;
            eye2Script.Firing = true;
            //Eyeball.SetActive(true);
        }
    }
}
