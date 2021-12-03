using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraVibrando : MonoBehaviour
{
    public float duracion = 1.5f;
    public float magnitud = 1.5f;


    public IEnumerator Vibra()
    {
        Vector3 posicionOriginal = transform.localPosition;
        float elapsed = 0;
        while (elapsed < duracion)
        {
            float x = Random.Range(-1f, 1f) * magnitud;
            float y = Random.Range(-1, 1f) * magnitud;
            transform.localPosition = new Vector3(posicionOriginal.x+x,posicionOriginal.y+y, posicionOriginal.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = posicionOriginal;
    }
}
