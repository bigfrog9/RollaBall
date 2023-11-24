using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private int Count;

    public int CurrentLevel;

    public TextMeshProUGUI CountText;

    public TextMeshProUGUI WinText;

    public bool isGrey = false;

    public bool isYellow = false;
    public bool isGreen = false;

    public float speed = 0;

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    //player colour
    public Material KeyColour;

    //Gates
    public GameObject YellowGate;
    public GameObject GreenGate;

    //Gate colliders

    Collider GreenCollider;
    Collider GreenCollider2;
    Collider YellowCollider;

    //Platforms
    public GameObject GreenPlat;

    // Start is called before the first frame update

    public void PlayerKill()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        SceneManager.LoadSceneAsync(1);
    }

    void Start()
    {
        //grabbing colliders
        GreenCollider = GreenGate.gameObject.GetComponent<Collider>();
        GreenCollider2 = GreenPlat.gameObject.GetComponent<Collider>();

        YellowCollider = YellowGate.gameObject.GetComponent<Collider>();

        //resetting player colour
        KeyColour.color = Color.red;

        rb = GetComponent<Rigidbody>();

        //number of coins left
        Count = 10;

        SetCountText();
    }

    //checking if player can pass through gates
    void GateCheck()
    {
        if (isYellow)
        {
            GreenCollider.isTrigger=false;
            GreenCollider2.isTrigger = false;

            YellowCollider.isTrigger=true;

            //GreenGate.gameObject.SetActive(true);
            //YellowGate.gameObject.SetActive(false);

            //GreenPlat.gameObject.SetActive(true);
        }

        if (isGreen)
        {
            YellowCollider.isTrigger=false;

            GreenCollider.isTrigger=true;
            GreenCollider2.isTrigger=true;

            //YellowGate.gameObject.SetActive(true);
            //GreenGate.gameObject.SetActive(false);

            //GreenPlat.gameObject.SetActive(false);
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

        GateCheck();
    }

    void SetCountText()
    {
        CountText.text = "Remaining: " + Count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Sword"))
        {
            KeyColour.color = Color.grey;

            other.gameObject.SetActive(false);

            isGrey = true;

            isYellow = false;
            isGreen = false;
        }

        //picking up coins
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);

            Count--;

            SetCountText();

            if(Count == 0)
            {
                if (CurrentLevel == 3)
                {
                    WinText.gameObject.SetActive(true);

                }

                else if(CurrentLevel < 3)
                {
                    //This equation makes it easy to add more levels
                    SceneManager.LoadSceneAsync(CurrentLevel + 1);
                }
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (isGrey)
            {
                other.gameObject.SetActive(false);
            }

            if (isGrey == false)
            {
                PlayerKill();
            }
        }

        if (other.gameObject.CompareTag("Killzone"))
        {
            PlayerKill();
        }

        //picking up yellow key
        if(other.gameObject.CompareTag("Yellow Key"))
        {
            other.gameObject.SetActive(false);

            isYellow = true;
            isGreen = false;

            KeyColour.color = Color.yellow;
        }

        //picking up green key
        if(other.gameObject.CompareTag("Green Key"))
        {
            other.gameObject.SetActive(false);

            isGreen = true;
            isYellow = false;

            KeyColour.color = Color.green;

        }
    }
}
