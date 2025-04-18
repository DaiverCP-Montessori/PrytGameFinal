using UnityEngine;

public class DetectRayLimit : MonoBehaviour {


    void Start()
    {

    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.CompareTag("Player"))
        {
            Seleccion.instance.distancia = 2.25f;

        }
    }
    private void OnTriggerExit(Collider SueltaObjeto)
    {
        if (SueltaObjeto.CompareTag("Player"))
        {
            Seleccion.instance.distancia = 1.5f;
        }
    }

}
