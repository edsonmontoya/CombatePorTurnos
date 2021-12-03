using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght, posicionInicial;
    public GameObject camara;
    public float efectoParallax;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

    }
    private void FixedUpdate()
    {
        float dist = (camara.transform.position.x * efectoParallax);
        transform.position = new Vector3(posicionInicial + dist, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
