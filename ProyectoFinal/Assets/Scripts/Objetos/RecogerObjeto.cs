using Unity.VisualScripting;
using UnityEngine;

public class RecogerObjeto : MonoBehaviour
{
    public GameObject handpoint;
    public RecogerObjeto instance;
    private GameObject pickedObject = null;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        Soltar();
    }

    private void OnTriggerStay(Collider objeto)
    {
        if (objeto.gameObject.CompareTag("ObjetoRecoger"))
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                objeto.GetComponent<Rigidbody>().useGravity = false;

                objeto.GetComponent<Rigidbody>().isKinematic = true;

                objeto.transform.position = handpoint.transform.position;

                objeto.gameObject.transform.SetParent(handpoint.gameObject.transform);

                pickedObject = objeto.gameObject;
            }
        }
    }

    public void Soltar()
    {
        if (pickedObject != null)
        {
            if (Input.GetKey("r"))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;

                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);

                pickedObject = null;
            }
        }
    }
}
