using UnityEngine;

public class MoverCamaraRaton : MonoBehaviour
{
    public float sensibilidad = 2f;
    private float rotacionX = 0f;

    float movConCamX;
    float movConCamY;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        movConCamX = Input.GetAxis("Mouse X") * sensibilidad;
        movConCamY = Input.GetAxis("Mouse Y") * sensibilidad;


        transform.parent.transform.rotation = Quaternion.Euler(0, transform.parent.transform.rotation.eulerAngles.y + movConCamX, 0);

        rotacionX -= movConCamY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

    }

}
