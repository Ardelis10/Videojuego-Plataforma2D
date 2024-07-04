using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;

public class JugadorController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidad = 10f;
    public float salto = 5f;
    [SerializeField] private AudioClip perder;
    private int contador; 
    //Inicializo variables para los textos  
    public TMP_Text textoContador, textoGanar, Timer;
    private float tiempoRestante = 60.0f; // Variable para el tiempo restante
    private bool juegoTerminado = false;  // Variable para controlar si el juego ha terminado

    private bool puedeActualizarContador = true;  // Cooldown para el contador
    private float tiempoCooldown = 0.5f;  // Tiempo de cooldown en segundos

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        //Inicio el contador a 0   
        contador = 0; 
        
        setTextoContador();   //Inicio el texto de ganar a vacío   
        textoGanar.text = ""; 

        rb.freezeRotation = true; // Fijar la rotación en el eje Z
    }

    void Update()
    {
        if (juegoTerminado)
        {
            ControladorSonido.Instance.EjecutarSonido(perder);
            return;  // Si el juego ha terminado, no permitimos más movimientos
            SceneManager.LoadScene("Juego");
        }

        // Movimiento horizontal
        float movimientoH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoH * velocidad, rb.velocity.y);

        // Obtener la entrada del usuario
        float moveY = Input.GetKey(KeyCode.UpArrow) ? 1 : 0;

        // Mover el personaje hacia arriba
        Vector3 movement = new Vector3(0, moveY, 0);
        transform.position += movement * salto * Time.deltaTime;

        // Decremento el tiempo restante
        tiempoRestante -= Time.deltaTime;

        // Actualizo el texto del temporizador
        Timer.text = "Tiempo: " + Mathf.Clamp(tiempoRestante, 0, 60).ToString("F2");

        // Si el tiempo llega a cero, muestro el mensaje de "Perdiste"
        if (tiempoRestante <= 0)
        {
            textoGanar.text = "¡Perdiste!";
            juegoTerminado = true;
        }
    }

    //Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada  
    void OnTriggerEnter2D(Collider2D other)     
    {   
        if (!puedeActualizarContador)
        {
            return;
        } 

        if (other.gameObject.CompareTag("Coleccionable")) 
        { 
            other.gameObject.SetActive(false);
            
            // Aumento el contador en uno  
            contador++; 

            // Actualizo el texto del contador    
            setTextoContador(); 
        } 
        else if(other.gameObject.CompareTag("Obstaculo")) 
        { 
            ReiniciarJuego();
        }

        StartCoroutine(CooldownContador());
    }

    IEnumerator CooldownContador()
    {
        puedeActualizarContador = false;
        yield return new WaitForSeconds(tiempoCooldown);
        puedeActualizarContador = true;
    }

    //Actualizo el texto del contador (O muestro el de ganar si las ha cogido todas)  
    void setTextoContador()
    {   
        textoContador.text = "Contador: " + contador.ToString();   
        
        if (contador >= 10)
        {   
            textoGanar.text = "¡Ganaste!"; 
            juegoTerminado = true;  // El jugador ha ganado, detener el juego
            
            // Cargar el siguiente nivel
            SceneManager.LoadScene("Nivel2");
        } 
    }

    void ReiniciarJuego() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Esta línea de código carga la escena actual nuevamente.
    }
}
