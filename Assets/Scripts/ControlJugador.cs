using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rbody;
    public Animator anmtr;
    public float movementSpeed = 0f;
    public float currentSpeed;
    public SpriteRenderer sprRenderer;
    public float raycastLength;
    public LayerMask groundLayer;
    public Transform feet;
    public float tiempo;
    public float salto;
    public float DobleSalto;
    public bool puedeSaltar = true;
    public bool dobleSalto = false;
    public bool estaMoviendose = false;
    public bool estaAtacando = false;
    public bool armaEnMano = false;
    public bool saltandoConArma = true;
    public bool doblesaltoconarma = false;
    public GestionPaneles gestionPaneles;
    public GestionCamaras gestionCamaras;
    public Characters characters;
    public StatusPanel statusJugador;
    [SerializeField] Text textoZona;
    private void Update()
    {
        if(rbody.gravityScale == 1)
        {
            gestionPaneles.barraOpciones.SetActive(true);
            gestionPaneles.Combate.SetActive(false);
            gestionPaneles.combateEncendido = false;
            rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        tiempo = tiempo += Time.deltaTime;
        Inputs();
    }
    //Esta funcion es un cagadero lo se (Ocupo optimizarlo)
    void Inputs()
    {
        currentSpeed = Input.GetAxis("Horizontal");
        anmtr.SetBool("isMoving", false);
        if (currentSpeed != 0)
        {
            estaMoviendose = true;
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
        if (Input.GetKeyDown(KeyCode.W) && currentSpeed != 0 && puedeSaltar == true)
        {
            tiempo = 0;
            anmtr.SetBool("corriendoaSaltar", true);
            ValoresSaltoNormal();
            dobleSalto = true;
            puedeSaltar = false;
            if (Input.GetKeyDown(KeyCode.W) && currentSpeed != 0 && armaEnMano == true && saltandoConArma == true)
            {
                tiempo = 0;
                anmtr.SetBool("saltarCorriendoArma", true);
                ValoresSaltoDoble();
                doblesaltoconarma = true;
                saltandoConArma = false;
            }
        }
       

        if (armaEnMano == true && currentSpeed != 0)
        {
            estaMoviendose = true;
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
            estaMoviendose = false;
            anmtr.SetBool("armaMano", true);
            anmtr.SetBool("corriendoconArma", false);
        }
        if(Input.GetKeyDown(KeyCode.W) && armaEnMano == true && saltandoConArma == true)
        {
            saltandoConArma = false;
            tiempo = 0;
            ValoresSaltoNormal();
            doblesaltoconarma = true;
            
        }
        if (Input.GetKeyDown(KeyCode.W) && doblesaltoconarma == false)
        {
            tiempo = 0;
            ValoresSaltoDoble();
            doblesaltoconarma = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && anmtr.GetBool("armaMano"))
        {
            estaAtacando = true;
            anmtr.SetBool("estaAtacando", true);
            anmtr.SetBool("armaMano", false);
        }
        if (currentSpeed == 0 && anmtr.GetBool("armaMano"))
        {
            estaMoviendose = false;
            tiempo = tiempo += Time.deltaTime;
        }
        else
        {
            tiempo = 0;
        }
        if (tiempo >= 5)
        {
            armaEnMano = false;
            anmtr.SetBool("isIdle", true);
        }
        if( tiempo >= 12)
        {
            anmtr.SetBool("SuperIdle", true);
        }
        else
        {
            anmtr.SetBool("SuperIdle", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            armaEnMano = false;
            movementSpeed = 0f;
            estaAtacando = true;
            tiempo = 0;
            Atacando();
        }
        else
        {
            estaAtacando = false;
            movementSpeed = 5f;
        }
        
        if (dobleSalto == true)
        {
            salto = 0;
            DobleSalto = 0;
        }
        else
        {
            salto = 4;
            DobleSalto = 3;
        }
        if (doblesaltoconarma == true)
        {
            salto = 0;
            DobleSalto = 0;
        }
        else
        {
            salto = 4;
            DobleSalto = 3;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            puedeSaltar = false;
            tiempo = 0;
            ValoresSaltoNormal();
            if (Input.GetKeyDown(KeyCode.W) && puedeSaltar == false)
            {
                tiempo = 0;
                anmtr.SetBool("isMoving", false);
                ValoresSaltoDoble();
                anmtr.SetBool("dobleSalto", true);
                dobleSalto = true;
                puedeSaltar = false;
            }
        }
        if(puedeSaltar == false)
        {
            anmtr.SetBool("isMoving", false);
            anmtr.SetBool("puedeSaltar", true);
        }
        if(puedeSaltar == true)
        {
            anmtr.SetBool("corriendoaSaltar", false);
        }
        if(saltandoConArma == false)
        {
            anmtr.SetBool("corriendoconArma", false);
            anmtr.SetBool("saltandoconarma", true);
        }
        else
        {
            anmtr.SetBool("saltarCorriendoArma", false);
        }
       
        if(doblesaltoconarma == true)
        {
            anmtr.SetBool("dobleSaltoConArma", true);
        }
        else
        {
            anmtr.SetBool("dobleSaltoConArma", false);
        }

        RaycastHit2D hit = Physics2D.Raycast(feet.position, Vector2.down, raycastLength, groundLayer);
        if (hit.collider)
        {
            doblesaltoconarma = false;
            saltandoConArma = true;
            dobleSalto = false;
            puedeSaltar = true;
            anmtr.SetBool("puedeSaltar", false);
            anmtr.SetBool("dobleSalto", false);
            anmtr.SetBool("saltandoconarma", false);
            anmtr.SetBool("dobleSaltoConArma", false);
            if (armaEnMano == true)
            {
                anmtr.SetBool("armaMano", true);
            }
        }
        else
        {
            saltandoConArma = false;
            puedeSaltar = false;
        }
       
        
    }
void Atacando()
    {
        anmtr.SetBool("isMoving", false);
        anmtr.SetBool("estaAtacando", true);
        StartCoroutine("Esperar");
    }
    private void FixedUpdate()
    {
        Movement();
        //Jump();
    }
    public void ValoresSaltoNormal()
    {
        rbody.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
    }
    public void ValoresSaltoDoble()
    {
        rbody.AddForce(Vector2.up * DobleSalto, ForceMode2D.Impulse);
    }
    void Movement()
    {
        rbody.velocity = currentSpeed * Vector2.right * movementSpeed + rbody.velocity.y * Vector2.up;
    }
  
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.1f);
        armaEnMano = true;
        anmtr.SetBool("estaAtacando", false);
        anmtr.SetBool("isIdle", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemigoZn1"))
        {
            gestionCamaras.CamaraEnCombateZona1();
            rbody.gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            characters.ManaActual._Valor = characters.Mana._Valor;
            characters.vidaActual._Valor = characters.Salud._Valor;
            statusJugador.barraVida.value = characters.vidaActual._Valor / characters.Salud._Valor;
            statusJugador.barraMana.value = characters.ManaActual._Valor / characters.Mana._Valor;
            statusJugador.healthSliderBar.color = new Color(0.128649f, 0.5566f, 0.1878753f, 1);
            //Destroy(collision.gameObject);
            if (rbody.gravityScale == 0)
            {
                gestionPaneles.barraOpciones.SetActive(false);
                gestionPaneles.Combate.SetActive(true);
                gestionPaneles.combateEncendido = true;
            }
        }
        if (collision.CompareTag("Ciudad"))
        {
            textoZona.text = "CIUDAD";
        }
        if (collision.CompareTag("AfuerasCiudad"))
        {
            textoZona.text = "AFUERAS DE LA CIUDAD";
        }

    }
    
}

