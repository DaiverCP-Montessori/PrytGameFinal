using UnityEngine;

public class Seleccion : MonoBehaviour
{
    LayerMask mask;

    public float distancia = 1.5f;
    void Start()
    {
        mask = LayerMask.GetMask("Interactive");
    }
    void Update()
    {
        RaycastHit toque;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out toque, distancia, mask))
        {
            if (toque.collider.tag == "ObjectInteract")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                     toque.collider.transform.GetComponent<InteractuarObjeto>().ActivarObjeto();
                }
            }
        }
    }
}
