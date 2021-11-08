using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour
{
    public Rigidbody2D rbody;
    public Animator anmtr;
    public float movementSpeed = 0f;
    public float currentSpeed;
    public SpriteRenderer sprRenderer;
    public float raycastLength;
    public LayerMask groundLayer;
    public Transform feet;
    public float tiempo;
    private void Update()
    {
        tiempo = tiempo += Time.deltaTime;
        // anmtr.SetBool("isIdle", true);
        Inputs();
        void Inputs()
        {
            currentSpeed = Input.GetAxis("Horizontal");
            anmtr.SetBool("isMoving", false);

            if (currentSpeed != 0) 
                {
                anmtr.SetBool("isMoving", true);
                    if (currentSpeed < 0)
                    {
                        sprRenderer.flipX = true;
                    }
                    else
                    {
                        sprRenderer.flipX = false;
                    }
                }
            if (anmtr.GetBool("armaMano") && currentSpeed != 0)
            {
                anmtr.SetBool("corriendoconArma", true);
                if (currentSpeed < 0)
                {
                    sprRenderer.flipX = true;
                }
                else
                {
                    sprRenderer.flipX = false;
                }
            }
            else
            {
                anmtr.SetBool("corriendoconArma", false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && anmtr.GetBool("armaMano"))
            {
                anmtr.SetBool("estaAtacando", true);
                anmtr.SetBool("armaMano", false);
            }
            if(currentSpeed == 0 && anmtr.GetBool("armaMano"))
            {
                tiempo = tiempo += Time.deltaTime;
            }
            else
            {
                tiempo = 0;
            }
            if (tiempo >= 5)
            {
                anmtr.SetBool("isIdle", true);
            }



                RaycastHit2D hit = Physics2D.Raycast(feet.position, Vector2.down, raycastLength, groundLayer);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tiempo = 0;
            Atacando();
        }
        else
        {
            movementSpeed = 5f;
            anmtr.SetBool("armaMano", true);
        }
    }
     void Atacando()
    {
        movementSpeed = 0f;
        anmtr.SetBool("isMoving", false);
        anmtr.SetBool("estaAtacando", true);
        StartCoroutine("Esperar");
    }
    private void FixedUpdate()
    {
        Movement();
        //Jump();
    }
    void Movement()
    {
        rbody.velocity = currentSpeed * Vector2.right * movementSpeed + rbody.velocity.y * Vector2.up;
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.1f);
        anmtr.SetBool("armaMano", true);
        anmtr.SetBool("estaAtacando", false);
        anmtr.SetBool("isIdle", false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            SceneManager.LoadScene("PrototipoCombate 1");
        }
        
    }
}

