using UnityEditor;
using UnityEngine;

public class SpawnearMonedas : MonoBehaviour
{
    public GameObject monedaPrefab;
    int cantidad;
    float crono = 0f;

    void Start()
    {
        //Vector3
    }
    void Update()
    {
        if (cantidad <= 5)
        {
            if (crono >= 8)
            {
                Vector3 posicionRandom = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
                Vector3 posicionFinal = transform.position + posicionRandom;
                Instantiate(monedaPrefab, posicionFinal, Quaternion.identity);
                crono = 0;
                cantidad++;
            }

            else
            {
                crono += 1 * Time.deltaTime;
                Debug.Log("Segundos de moneda nueva" + crono);

            }
        }
    }

}
