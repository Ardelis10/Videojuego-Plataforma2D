using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Personajes : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento
    public float posicionMaximaX = 3f; // Posición máxima en X que la barra alcanzará
    public float posicionMinimaX = -3f; // Posición mínima en X que la barra alcanzará

    private bool moviendoDerecha = true; // Para controlar si la barra se está moviendo hacia la derecha o hacia la izquierda

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la posición actual de la barra
        Vector3 posicionActual = transform.position;

        // Si está moviéndose a la derecha
        if (moviendoDerecha)
        {
            // Incrementar la posición X
            posicionActual.x += velocidad * Time.deltaTime;

            // Si ha alcanzado o superado la posición máxima en X, cambiar la dirección
            if (posicionActual.x >= posicionMaximaX)
            {
                posicionActual.x = posicionMaximaX; // Ajustar exactamente a la posición máxima
                moviendoDerecha = false; // Cambiar la dirección a izquierda
            }
        }
        else
        {
            // Si está moviéndose a la izquierda, disminuir la posición X
            posicionActual.x -= velocidad * Time.deltaTime;

            // Si ha alcanzado o superado la posición mínima en X, cambiar la dirección
            if (posicionActual.x <= posicionMinimaX)
            {
                posicionActual.x = posicionMinimaX; // Ajustar exactamente a la posición mínima
                moviendoDerecha = true; // Cambiar la dirección a derecha
            }
        }

        // Aplicar la nueva posición a la barra
        transform.position = posicionActual;
    }
}
