using UnityEngine;

public class Seleccion : MonoBehaviour
{
    public static Seleccion instance;
    LayerMask mask;
    public float distancia = 1.5f;
    public Texture2D puntero;
    GameObject texto;
    GameObject textoRecoger;
    GameObject ultimoReconocido = null;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (texto == null)
        {
            texto = GameObject.Find("TextoDetectar");
        }
        if (textoRecoger == null)
        {
            textoRecoger = GameObject.Find("TextoRecoger");
        }
        mask = LayerMask.GetMask("Interactive");
        texto.SetActive(false);
        textoRecoger.SetActive(false);
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
            if (toque.collider.tag == "Moneda")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    toque.collider.transform.GetComponent<InteractuarObjeto>().ActivarObjeto();
                    Debug.Log("Moneda Añadida");
                    ManagerUI.instance.AniadirMoneda(1);
                    //Para condiderar con animacion
                    /*InteractuarObjeto eliminarConAnimacion = toque.collider.transform.GetComponent<InteractuarObjeto>();

                    if (eliminarConAnimacion != null)
                    {
                        StartCoroutine(eliminarConAnimacion.ActivarObjeto());
                    }*/
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
            if (ultimoReconocido.CompareTag("Moneda"))
            {
                textoRecoger.SetActive(true);
            }
            else
            {
                texto.SetActive(true);
            }
        }
        else
        {
                textoRecoger.SetActive(false);
                texto.SetActive(false);
        }
    }

}
