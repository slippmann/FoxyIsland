using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public bool isGrounded;
    public bool isAtEnd;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Get foot collider (box collider) from player
        if (collision.otherCollider.GetType() == typeof(BoxCollider2D))
        {
            if (collision.gameObject.CompareTag("Ground"))
                isGrounded = true;
            if (collision.gameObject.CompareTag("Void"))
                FindObjectOfType<gameManager>().GameOver();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Get foot collider (box collider) from player
        if (collision.otherCollider.GetType() == typeof(BoxCollider2D))
        {
            if (collision.gameObject.CompareTag("Ground"))
                isGrounded = false;
        }       
    }
}
