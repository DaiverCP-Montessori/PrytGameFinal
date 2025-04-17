using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Moneda : MonoBehaviour
{
    public Light luzTenue;
    public float intervalo = 3f;
    public float duracion = 1f;
    public Color colorEmission = new Color(1f, 0.9f, 0.6f);
    public float intensidadEmission = 0.3f;

    private Material material;
    private Color emissionOriginal;
    private bool activando = false;
    public float Radiodeteccion = 6f;
    public GameObject monedaPrefB;
    float crono = 0f;


    void Start()
    {
        /*
        material = GetComponent<Renderer>().material;

        if (!material.HasProperty("_EmissionColor"))
        {
            Debug.LogWarning("Este material no tiene Emission habilitado.");
            return;
        }

        material.EnableKeyword("_EMISSION");
        emissionOriginal = material.GetColor("_EmissionColor");
        luzTenue.intensity = 0;

        InvokeRepeating("IniciarReflejo", intervalo, intervalo);
        */
    }

    void Update()
    {   
        
        if (crono >= 8)
        {
            Vector3 posicionRandom = new Vector3(Random.Range(-10, 10),0, Random.Range(-10, 10));
            Vector3 posicionFinal = transform.position + posicionRandom;
            Instantiate(monedaPrefB, posicionFinal, Quaternion.identity);
            crono = 0;
        }
       
        else
        {
            crono += 1 * Time.deltaTime;
            Debug.Log("Segundos de moneda nueva" + crono);
            
        }      
    }
    /*
    void IniciarReflejo()
    {
        if (!activando)
        {
            StartCoroutine(Reflejo());
        }
    }

    System.Collections.IEnumerator Reflejo()
    {
        activando = true;
        float tiempo = 0f;

        // Activar luz y brillo
        while (tiempo < duracion / 2f)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / (duracion / 2f);
            luzTenue.intensity = Mathf.Lerp(0, 0.1f, t); // luz suave
            material.SetColor("_EmissionColor", Color.Lerp(emissionOriginal, colorEmission * intensidadEmission, t));
            yield return null;
        }

        tiempo = 0f;

        // Desactivar luz y brillo
        while (tiempo < duracion / 2f)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / (duracion / 2f);
            luzTenue.intensity = Mathf.Lerp(0.1f, 0, t);
            material.SetColor("_EmissionColor", Color.Lerp(colorEmission * intensidadEmission, emissionOriginal, t));
            yield return null;
        }

        activando = false;
    }
    */

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radiodeteccion);
    }
}
