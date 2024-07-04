using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Barra : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento
    public float alturaMaxima = 3f; // Altura máxima que la barra alcanzará
    public float alturaMinima = -3f; // Altura mínima que la barra alcanzará

    private bool subiendo = true; // Para controlar si la barra está subiendo o bajando
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la posición actual de la barra
        Vector3 posicionActual = transform.position;

        // Si está subiendo
        if (subiendo)
        {
            // Incrementar la posición Y
            posicionActual.y += velocidad * Time.deltaTime;

            // Si ha alcanzado o superado la altura máxima, cambiar la dirección
            if (posicionActual.y >= alturaMaxima)
            {
                posicionActual.y = alturaMaxima; // Ajustar exactamente a la altura máxima
                subiendo = false; // Cambiar la dirección a bajando
            }
        }
        else
        {
            // Si está bajando, disminuir la posición Y
            posicionActual.y -= velocidad * Time.deltaTime;

            // Si ha alcanzado o superado la altura mínima, cambiar la dirección
            if (posicionActual.y <= alturaMinima)
            {
                posicionActual.y = alturaMinima; // Ajustar exactamente a la altura mínima
                subiendo = true; // Cambiar la dirección a subiendo
            }
        }

        // Aplicar la nueva posición a la barra
        transform.position = posicionActual;
    
    }
}