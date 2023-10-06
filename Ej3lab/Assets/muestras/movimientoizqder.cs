using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoizqder : MonoBehaviour
{
    public float velocidad = 2.0f; // La velocidad de movimiento
    public float distancia = 5.0f; // La distancia total que el objeto debe recorrer

    private Vector3 puntoInicial; // La posición inicial del objeto
    private Vector3 puntoFinal;   // La posición final del objeto

    void Start()
    {
        puntoInicial = transform.position;
        puntoFinal = puntoInicial + Vector3.right * distancia;
    }

    void Update()
    {
        float tiempo = Mathf.PingPong(Time.time * velocidad, 1.0f); // Usamos PingPong para obtener un valor entre 0 y 1 en bucle

        // Interpolamos entre el punto inicial y final
        transform.position = Vector3.Lerp(puntoInicial, puntoFinal, tiempo);
    }
}
