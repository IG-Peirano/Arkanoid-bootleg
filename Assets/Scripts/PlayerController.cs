using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] float speed;
    private float outOfBounds = 440.0f;


    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed * horizontalInput;

        if(GetComponent<Transform>().position.x < -outOfBounds)
        {
            transform.position = new Vector2(-outOfBounds, transform.position.y);
        }

        if(GetComponent<Transform>().position.x > outOfBounds)
        {
            transform.position = new Vector2(outOfBounds, transform.position.y);
        }
    }


}