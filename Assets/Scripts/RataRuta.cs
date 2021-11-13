using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataRuta : MonoBehaviour
{
    public int hitPoints;
    public float speed;
    public float speedUp;
    public Rigidbody2D rbody;
    public SpriteRenderer sprRenderer;
    public float offset;
    public float raycastLenght;
    public LayerMask groundLayer;


    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1.5f);
        speedUp = 0;
        rbody.position = new Vector2(rbody.position.x, rbody.position.y - 0.005f);
        
    }
    void Update()
    {
        CheckForLimits();
        if (speedUp == 3f)
        {
            rbody.position = new Vector2(rbody.position.x, rbody.position.y + 0.005f);
            StartCoroutine("Esperar");
        }
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
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BalaPsiquica"))
        {
            raycastLenght = 20;
            rbody.constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<RataRuta>().speedUp = 3f;
            
        }
        if (collision.CompareTag("Piso"))
        {
            raycastLenght = 0.5f;
            rbody.constraints = RigidbodyConstraints2D.None;
        }
    }
}
