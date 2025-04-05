using UnityEngine;

public class Moneda : MonoBehaviour
{
    public float brilloDuracion = 0.5f;
    public float brilloTiempoRepeticion = 2f;
    public float intensidadBrillo = 4f;
    public Color colorDestello = Color.yellow;
    private Material materialOriginal;
    private Color colorOriginal;
    public Light Luz;
    
    void Start()
    {
        Luz.intensity = 0;
        materialOriginal = GetComponent<Renderer>().material;

        InvokeRepeating("ActivarLuz", brilloTiempoRepeticion, brilloTiempoRepeticion);

    }
    void ActivarDestello()
    {
        StartCoroutine(DestelloLuz());
    }

    System.Collections.IEnumerator DestelloLuz()
    {
        float tiempo = 0;

        while(tiempo < brilloDuracion)
        {
            tiempo = +Time.deltaTime;
            Luz.intensity = Mathf.Lerp(0, intensidadBrillo, tiempo / (brilloDuracion / 2));
            yield return null;
        }

        tiempo = 0;

        while (tiempo < brilloDuracion)
        {
            tiempo = +Time.deltaTime;
            Luz.intensity = Mathf.Lerp(0, 0, tiempo / (brilloDuracion / 2));
            yield return null;
        }
    }

    /**
     * 
     * 

        colorOriginal = materialOriginal.GetColor("_EmissionColor");

        InvokeRepeating("ActivarDestello", brilloTiempoRepeticion, brilloTiempoRepeticion);
    }
    void ActivarDestello()
    {
        StartCoroutine(Destello());

    }

    System.Collections.IEnumerator Destello()
    {
        materialOriginal.SetColor("_EmissionColor", colorDestello * 2f);

        yield return new WaitForSeconds(brilloDuracion);

        materialOriginal.SetColor("_EmissionColor", colorOriginal);
    }
     */

/**
 * void Start()
{
    Luz.intensity = 0;
    materialOriginal = GetComponent<Renderer>().material;

    if (!materialOriginal.HasProperty("_EmissionColor"))
    {
        Debug.LogError("El material no tiene emision");
            return;
    }


    colorOriginal = materialOriginal.GetColor("_EmissionColor");

    InvokeRepeating("ActivarDestello", brilloTiempoRepeticion, brilloTiempoRepeticion);
}
void ActivarDestello()
{
    if (!parpadear)
    {
        StartCoroutine(Destello());
    }
}

System.Collections.IEnumerator Destello()
{
    parpadear = true;

    materialOriginal.EnableKeyword("_EMISSION");
    materialOriginal.SetColor("_EmissionColor", colorDestello * intencidadBrillo);

    yield return new WaitForSeconds(brilloDuracion);

    materialOriginal.SetColor("_EmissionColor", colorOriginal);
    materialOriginal.DisableKeyword("_EMISSION");

    parpadear = false;
}*/
}
