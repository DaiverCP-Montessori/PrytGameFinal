using UnityEngine;

public class Seleccion : MonoBehaviour
{
    LayerMask mask;

    
    public float distancia = 1.5f;
    public Texture2D puntero;
    public GameObject texto;
    GameObject ultimoReconocido = null;
    void Start()
    {
        mask = LayerMask.GetMask("Interactive");
        texto.SetActive(false);
    }
    void Update()
    {
        RaycastHit toque;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out toque, distancia, mask))
        {
            Deseleccionar();
            ObjetoSeleccionado(toque.transform);
            if (toque.collider.tag == "ObjectInteract")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                     toque.collider.transform.GetComponent<InteractuarObjeto>().ActivarObjeto();
                }
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        }
        else
        {
            Deseleccionar();
        }
    }
    void ObjetoSeleccionado(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoReconocido = transform.gameObject;
    }

    void Deseleccionar()
    {
        if (ultimoReconocido)
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }

    void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
        GUI.DrawTexture(rect, puntero);
        if (ultimoReconocido)
        {
            texto.SetActive(true);
        }
        else
        {
            texto.SetActive(false);  
        }
    }

}
