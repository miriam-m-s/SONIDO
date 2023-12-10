using BansheeGz.BGSpline.Curve;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mar : MonoBehaviour
{
    public BGCurve curva;
    public float distanciaMaxima = 10f;  // Ajusta según sea necesario
    public float velocidad = 5f;
    Cursor cursor;
    private float distanciaRecorrida = 0f;
    private void Start()
    {
        curva = GetComponent<BGCurve>();

    }
    void Update()
    {
        
    }
}
