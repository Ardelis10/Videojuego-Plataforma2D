using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void escenaMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void escenaNivel1()
    {
        SceneManager.LoadScene("Juego");

    }

     public void escenaNivel2()
    {
        SceneManager.LoadScene("Nivel2");

    }

     public void escenaNivel3()
    {
        SceneManager.LoadScene("Nivel3");

    }

  /*   public void escenaNivel4()
    {
        SceneManager.LoadScene("Juego -Nivel4");

    }

     public void escenaNivel5()
    {
        SceneManager.LoadScene("Juego -Nivel5");

    }

     public void escenaNivel6()
    {
        SceneManager.LoadScene("Juego -Nivel6");

    }*/

}
