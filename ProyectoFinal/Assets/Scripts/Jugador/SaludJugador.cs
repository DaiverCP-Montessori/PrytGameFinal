using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SaludJugador : MonoBehaviour
{
    public float salud = 200f;
    public float saludActual;
    public static SaludJugador instance;
    static Image imagenSalud;
    static Image imagenEstamina;
    bool recibeDanio;
    public float estamina = 101f;
    public float estamActual;
    float cronometro;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (imagenSalud == null)
        {
            imagenSalud = GameObject.Find("Salud").GetComponent<Image>();
        }
        if (imagenEstamina == null)
        {
            imagenEstamina = GameObject.Find("Estamina").GetComponent<Image>();
        }
        saludActual = salud;
        estamActual = estamina;
        recibeDanio = false;
    }

    void Update()
    {

    }
    public void TakeDamage(int danioRecibido)
    {
        recibeDanio = true;
        if (recibeDanio)
        {
            //Debug.Log("Ha recibido danio");
            saludActual -= danioRecibido;
            imagenSalud.fillAmount = saludActual / salud;

        }
        recibeDanio = false;
        Debug.Log("Salud Actual " + saludActual);
    }

    public void GastarEstamina()
    {
        //Debug.Log("Disminuir estamina " + estamActual);
        if (estamActual > 0f)
        {
            estamActual -= 1;
            imagenEstamina.fillAmount = estamActual / estamina;
        }
    }
    public void RecuperarEstamina()
    {
        
        if (estamActual < estamina)
        {
            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 2.5f)
            {
                estamActual += 1f;
                Debug.Log("Aumentando estamina " + estamActual);
                estamActual = Mathf.Clamp(estamActual, 0f, estamina);
                imagenEstamina.fillAmount = estamActual / estamina;
                cronometro = 0f;
            } 
        }
            
    }
}
