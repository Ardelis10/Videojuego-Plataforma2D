using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento
    public float tiempoVerificarPosicion = 2f; // Tiempo en segundos para verificar la posición del jugador
    private Vector3 posicionJugador; // Posición actual del jugador
    private float tiempoUltimaVerificacion; // Tiempo desde la última verificación

    // Referencia al jugador (debes asignarla en el Inspector)
    public Transform jugador;

    // Start is called before the first frame update
    void Start()
    {
        tiempoUltimaVerificacion = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la posición actual de la barra
        Vector3 posicionActual = transform.position;

        // Verificar si ha pasado el tiempo para verificar la posición del jugador
        if (Time.time - tiempoUltimaVerificacion >= tiempoVerificarPosicion)
        {
            tiempoUltimaVerificacion = Time.time; // Actualizar el tiempo de la última verificación

            // Verificar si el jugador está asignado
            if (jugador != null)
            {
                // Obtener la posición actual del jugador
                posicionJugador = jugador.position;

                // Iniciar el movimiento hacia la posición del jugador
                StartCoroutine(MoverHaciaPosicion(posicionJugador));
            }
        }
    
        // Aplicar la nueva posición a la barra
        transform.position = posicionActual;
    }

    // Función para mover la barra hacia la posición del jugador
    IEnumerator MoverHaciaPosicion(Vector3 posicionObjetivo)
    {
        while (transform.position != posicionObjetivo)
        {
            // Mover la barra hacia la posición del jugador usando Vector3.MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidad * Time.deltaTime);

            yield return null; // Esperar hasta el siguiente frame
        }
    }
}
