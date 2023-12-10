using BansheeGz.BGSpline.Curve;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mar : MonoBehaviour
{
    public BGCurve curva;
    public Transform player;


    Cursor cursor;
    BGCurvePointI[] puntos;

    public GameObject sonidoMar;
    private void Start()
    {
        curva = GetComponent<BGCurve>();
        puntos=curva.Points;

    }
    void Update()
    {
        // Llama a la funci�n para encontrar el punto m�s cercano
        BGCurvePointI puntoCercano = EncontrarPuntoMasCercano(player.position);
      
        // Ahora puedes hacer algo con el puntoCercano, como mover el objeto hacia �l
        MoverHaciaPunto(puntoCercano.PositionWorld);
    }
    private void MoverHaciaPunto(Vector3 destino)
    {
        // Calcula la nueva posici�n interpolada hacia el destino
        Vector3 nuevaPosicion = Vector3.Lerp(sonidoMar.transform.position, destino, 5 * Time.deltaTime);

        // Asigna la nueva posici�n al objeto
        sonidoMar.transform.position = nuevaPosicion;

        // Puedes agregar aqu� cualquier otra l�gica o comportamiento adicional que desees
    }
    private BGCurvePointI EncontrarPuntoMasCercano(Vector3 posicion)
    {
        BGCurvePointI puntoMasCercano = null;
        float distanciaMinima = float.MaxValue;

        // Itera sobre cada punto de la curva
        foreach (var punto in puntos)
        {
            // Calcula la distancia entre el punto y la posici�n del jugador
            float distancia = Vector3.Distance(punto.PositionWorld, posicion);

            // Actualiza el punto m�s cercano si la distancia actual es menor que la distancia m�nima
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                puntoMasCercano = punto;
            }
        }

        return puntoMasCercano;
    }
}
