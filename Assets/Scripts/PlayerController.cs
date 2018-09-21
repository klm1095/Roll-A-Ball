using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
        {
            transform.position = new Vector3(18.0f, 0.5f, 7.0f);
            
        }

        scoreText.text = "Score: " + score.ToString();
        if (count == 24)
        {
            winText.text = "You finished with a score of: " + score.ToString();
        }
    }
}
