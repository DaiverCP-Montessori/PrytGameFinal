using TreeEditor;
using UnityEngine;

public class ControlPlayerMov : MonoBehaviour
{
    public static ControlPlayerMov instance;
    public float velocidad = 5f;
    public float fuerzaDeSalto = 250f;

    private Rigidbody rb;
    //Variables de movimentos por teclado 
    float movimientoX;
    float movimientoY;

    //Controles 
    public bool caminar = false;
    bool salto = false;
    Animator animator;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Controles();
        Animacion();
    }

    void Controles()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        movimientoX = Input.GetAxis("Horizontal");

        movimientoY = Input.GetAxis("Vertical");

        if (movimientoX > 0 || movimientoY > 0)
        {
            caminar = true;
        }
        else
        {
            caminar = false;
        }


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
    
    void Animacion()
    {
        if (caminar)
        {
            animator.SetBool("Correr", true);
        }
        if (!caminar)
        {
            animator.SetBool("Correr", false);
        }
    }
    private void OnTriggerEnter(Collider colic)
    {
        if (colic.CompareTag("Ataque"))
        {
            Debug.Log("Daño");
        }
    }




}
