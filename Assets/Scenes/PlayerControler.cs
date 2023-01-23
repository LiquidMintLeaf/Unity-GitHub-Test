using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
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

        if (Input.GetKeyDown("space") || Input.GetKeyDown("w"))
        {
            foreach (Collider2D Collider in gameObject.GetComponentsInChildren<Collider2D>())
            {
                Collider.enabled = false;
            }

            if (Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.52f))
            {
                MovementVelocity.y = 10f;
            }
            /*            else
                        {
                            Debug.DrawRay(gameObject.transform.position, Vector3.down.normalized * 0.6f, Color.red, 2f);
                        }*/

            foreach (Collider2D Collider in gameObject.GetComponentsInChildren<Collider2D>())
            {
                Collider.enabled = true;
            }
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = MovementVelocity;
    }
}
