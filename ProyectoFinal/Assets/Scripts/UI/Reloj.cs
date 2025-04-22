using TMPro;
using UnityEngine;

public class Reloj : MonoBehaviour
{
    public TextMeshProUGUI TextoReloj;
    float horaSolar;

    private void Update()
    {
        horaSolar = CicloSol.instance.Hora;

        Prueba();
    }

    //***Tengo que decidirme cual usar***
    //Metodo que me muestra solo las horas pero son los minutos del ciclo del día
    void Prueba()
    {
        int hora = Mathf.FloorToInt(horaSolar);
        TextoReloj.text = $"{hora:00}:00";
    }
    //Metodo que me muestra tanto minutos como segundos para imitar una hora y sus minutos
    void Prueba2()
    {
        int hora = Mathf.FloorToInt(horaSolar);
        int minutos = Mathf.FloorToInt((horaSolar - hora) * 60);
        TextoReloj.text = $"{hora:00}:{minutos:00}";
    }

}
