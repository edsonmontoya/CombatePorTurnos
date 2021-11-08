using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataRuta : MonoBehaviour
{
    public int hitPoints;
    public float speed;
    public Rigidbody2D rbody;
    public SpriteRenderer sprRenderer;
    public float offset;
    public float raycastLenght;
    public LayerMask groundLayer;
    void Update()
    {
        CheckForLimits();
    }
    private void FixedUpdate()
    {
        rbody.velocity = Vector2.right * speed;
    }
    void CheckForLimits()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.right * offset, Vector2.down, raycastLenght, groundLayer);
        if (hit.collider == null)
        {
            offset *= -1;
            speed *= -1;
            sprRenderer.flipX = !sprRenderer.flipX;
        }
    }
}
