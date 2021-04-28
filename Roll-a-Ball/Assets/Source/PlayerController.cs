using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{

    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float movementX;
    private float movementY;

    private Rigidbody rb;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 8)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }
    }
}