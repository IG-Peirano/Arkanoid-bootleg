using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 125.0f;
    public AudioSource sound;
    private GameObject player;
    private AudioSource playerDeath;
    private Button button;

    public Text CounterText;
    private int Count = 0;
    private float yLimit = 130;

    // Update is called once per frame
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

        sound = GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");

        playerDeath = player.GetComponent<AudioSource>();

        button = GetComponent<Button>();

    }


    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        sound.Play();
        // audios[1].Play();

        // Hit the Racket?
        if (col.gameObject.name == "Player")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.CompareTag("Block"))
        {
            Count += 1;
            CounterText.text = "Score: " + Count;
        }
    }
    void FixedUpdate()
    {
        if (transform.position.y > -yLimit)
        {
            playerDeath.Play();
            //button.gameObject.SetActive(true);
        }
    }

}
