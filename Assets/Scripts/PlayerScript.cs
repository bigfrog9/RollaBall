using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private int Count;

    public TextMeshProUGUI CountText;

    public TextMeshProUGUI WinText;

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

    // Start is called before the first frame update
    void Start()
    {
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
            GreenGate.gameObject.SetActive(true);
            YellowGate.gameObject.SetActive(false);
        }

        if (isGreen)
        {
            YellowGate.gameObject.SetActive(true);
            GreenGate.gameObject.SetActive(false);
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
        //picking up coins
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);

            Count--;

            SetCountText();

            if(Count == 0)
            {
                WinText.gameObject.SetActive(true);
            }
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
