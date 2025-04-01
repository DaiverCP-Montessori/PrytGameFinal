using TreeEditor;
using UnityEngine;

public class ControlPlayerMov : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaDeSalto = 250f;

    private Rigidbody rb;
    float movimientoX;
    float movimientoY;
    bool salto = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Controles();
    }

    void Controles()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        movimientoX = Input.GetAxis("Horizontal");

        movimientoY = Input.GetAxis("Vertical");

         

        Vector3 move = transform.right * movimientoX + transform.forward * movimientoY;
        rb.MovePosition(rb.position + move * velocidad * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            salto = true;
        }
    }
    private void FixedUpdate()
    {
        if (salto)
        {
            Salto();
        }
    }

    private void Salto()
    {
        rb.AddForce(Vector3.up * fuerzaDeSalto);
        salto = false;
    }
    




}
