using UnityEngine;

public class MoverCamaraRaton : MonoBehaviour
{
    public float sensibilidad = 2f;
    private float rotacionX = 0f;
    public float limitUp = 74f;
    public float limitDown = -90f;
    public float posicionextra = 20f;
    

    /**Cambiar posicion de la cámara para evitar mostrar el modelo 3d
     */
    Vector3 posicionOrigen;
    float movConCamX;
    float movConCamY;
    public float positionAdds;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        posicionOrigen = transform.position;

    }

    void Update()
    {
        if (ControlPlayerMov.instance.caminar)
        {
            transform.position = transform.position + transform.forward * positionAdds;
        }
        else
        {
            transform.position = posicionOrigen;
        }

            movConCamX = Input.GetAxis("Mouse X") * sensibilidad;
        movConCamY = Input.GetAxis("Mouse Y") * sensibilidad;


        transform.parent.transform.rotation = Quaternion.Euler(0, transform.parent.transform.rotation.eulerAngles.y + movConCamX, 0);

        rotacionX -= movConCamY;
        rotacionX = Mathf.Clamp(rotacionX, limitDown, limitUp);

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

    }

}
