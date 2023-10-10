using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movcamara : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;

    void Update()
    {
        // Obtener la entrada del teclado para mover la c�mara
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el desplazamiento de la c�mara
        Vector3 desplazamiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical) * velocidadMovimiento * Time.deltaTime;

        // Aplicar el desplazamiento a la posici�n de la c�mara
        transform.Translate(desplazamiento);
    }
}
