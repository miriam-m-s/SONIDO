using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movcamara : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;

    void Update()
    {
        // Obtener la entrada del teclado para mover la cámara
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el desplazamiento de la cámara
        Vector3 desplazamiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical) * velocidadMovimiento * Time.deltaTime;

        // Aplicar el desplazamiento a la posición de la cámara
        transform.Translate(desplazamiento);
    }
}
