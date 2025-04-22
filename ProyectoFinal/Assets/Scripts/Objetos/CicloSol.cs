using JetBrains.Annotations;
using UnityEngine;

public class CicloSol : MonoBehaviour
{
    [Range(0.0f, 24f)] public float Hora = 12;
    public Transform Sol;

    private float solX;

    public float duracionDiaMins = 24;

    public static CicloSol instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        Hora += Time.deltaTime * (24 / (60 * duracionDiaMins));

        if (Hora >= 24)
        {
            Hora = 0;
        }

        RotacionSol();
        
    }

    void RotacionSol()
    {
        solX = 15 * Hora;

        Sol.localEulerAngles = new Vector3 (solX, 0, 0);

        if (Hora < 6 || Hora > 18)
        {
            Sol.GetComponent<Light>().intensity = 0;
        }
        else
        {
            Sol.GetComponent<Light>().intensity = 1;
        }
    }



}
