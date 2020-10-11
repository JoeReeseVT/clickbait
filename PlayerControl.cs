using UnityEngine;
using System;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public float speed = 0.2f;
    public string axisName = "Horizontal";
    public float jump = 1;


    [SerializeField] private LayerMask platformsLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();

    }

    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2D.collider != null;

    }

    void Update()
    {
        //movement code
        if (IsGrounded())
        {
            transform.position += transform.right * Input.GetAxis(axisName) * speed;
        }
        else
        {
            transform.position += transform.right * Input.GetAxis(axisName) * speed / 3;

        }

        //jump code
        if (IsGrounded() && Input.GetKey(KeyCode.UpArrow))
        {
            float jumpVelocity = 25f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
 
        }


        //flip character based on movement direction
        if (Input.GetAxis(axisName) < 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = 1.0f;
            transform.localScale = newScale;
        }
        else if (Input.GetAxis(axisName) > 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = -1.0f;
            transform.localScale = newScale;
        }
    }
}
