using UnityEngine;

public class MoverCamaraRaton : MonoBehaviour
{
    public float sensibilidad = 2f;
    private float rotacionX = 0f;
    public float limitUp = 74f;
    public float limitDown = -90f;
    public float posicionextra = 20f;


    /**Cambiar posicion de la cámara para evitar mostrar el modelo 3d
     
    Vector3 lastpos;
    Vector3 posicionOrigen;
    */
    float movConCamX;
    float movConCamY;
    //public float positionAdds = 1f;
    Transform player;

    void Awake()
    {
        
        //posicionOrigen = transform.position - player.position;
    }

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        //posicionOrigen = transform.position;

    }

    void Update()
    {
        
        //Actualiza la ultima posicion de la cámara de forma cosntante
        //lastpos = transform.position;
        if (!Pausa.instance.escenaPausada)
        {
            movConCamX = Input.GetAxis("Mouse X") * sensibilidad;
            movConCamY = Input.GetAxis("Mouse Y") * sensibilidad;


            transform.parent.transform.rotation = Quaternion.Euler(0, transform.parent.transform.rotation.eulerAngles.y + movConCamX, 0);

            rotacionX -= movConCamY;
            rotacionX = Mathf.Clamp(rotacionX, limitDown, limitUp);

            transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        }
        
    }

}
