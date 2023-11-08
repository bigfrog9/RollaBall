using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    public bool Firing=false;

    public Transform Player;


    public GameObject Teardrop;
    public Transform TearSpawn;

    [SerializeField] private float timer = 5;
    private float bulletTime;

    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Firing)
        {
            ShootAtPlayer();

        }
    }

    void ShootAtPlayer()
    {
            bulletTime -= Time.deltaTime;

            if (bulletTime > 0) return;
        
            bulletTime = timer;
        
            GameObject bulletObj = Instantiate(Teardrop, TearSpawn.transform.position, TearSpawn.transform.rotation) as GameObject;




        //Rigidbody TearRB = bulletObj.GetComponent<Rigidbody>();

        //TearRB.AddForce(TearRB.transform.forward * enemySpeed);
        //Destroy(TearRB, 5f);
    }
}
