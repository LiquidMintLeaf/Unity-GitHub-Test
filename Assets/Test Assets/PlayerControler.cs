using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    bool Jump = false;

    float TimeSinceJumpActivated = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            Jump = true;
            TimeSinceJumpActivated = 0f;
        }
        else
        {
            if (TimeSinceJumpActivated > 0.15f)
            {
                Jump = false;
            }

            TimeSinceJumpActivated = Mathf.Clamp(TimeSinceJumpActivated + Time.deltaTime, 0f, 1f);
        }
    }

    private void FixedUpdate()
    {
        Vector2 MovementVelocity = Vector2.zero;
        MovementVelocity.y = gameObject.GetComponent<Rigidbody2D>().velocity.y;

        if ((Input.GetKey("a") && !Input.GetKey("d")) || (!Input.GetKey("a") && Input.GetKey("d")))
        {
            if (Input.GetKey("a"))
            {
                MovementVelocity.x = -5f;
            }
            if (Input.GetKey("d"))
            {
                MovementVelocity.x = 5f;
            }
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = MovementVelocity;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Jump)
        {
            Jump = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 15f);
        }
    }
}
