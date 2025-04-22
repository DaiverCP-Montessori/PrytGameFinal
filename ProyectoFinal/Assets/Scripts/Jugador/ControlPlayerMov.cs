using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlPlayerMov : MonoBehaviour
{
    public static ControlPlayerMov instance;
    public float velocidad = 5f;
    public float velCorrer = 9f;
    public float velocidadActual;
    public float fuerzaDeSalto = 250f;

    private Rigidbody rb;
    //Variables de movimentos por teclado 
    float movimientoX;
    float movimientoY;

    //Controles 
    public bool caminar = false;
    bool salto = false;
    public bool enSuelo;
    bool Iscorrer = false;
    bool recuperado = false;
    bool cansado = false;
    public bool recibeDanio = false;
    float cronomRecuEstamina;
    float rayLengt = 0.30f;
    public float tiempoRecuperacion = 5f;

    Animator animator;

    [SerializeField]
    Transform posicionRayo;
    LayerMask capaSuelo;


    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        enSuelo = true;



    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        capaSuelo = LayerMask.GetMask("Suelo");
        if (posicionRayo == null)
        {
            posicionRayo = transform.Find("RayPost");
        }
    }
    void Update()
    {
        Controles();
        Animacion();
        Ray();
    }

    void Controles()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        InputCorrer();

        movimientoX = Input.GetAxis("Horizontal");

        movimientoY = Input.GetAxis("Vertical");


        animator.SetFloat("VelX", movimientoX);
        animator.SetFloat("VelY", movimientoY);


        Vector3 move = transform.right * movimientoX + transform.forward * movimientoY;
        rb.MovePosition(rb.position + move * velocidadActual * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            salto = true;
        }
    }


    private void FixedUpdate()
    {

    }
    private void InputCorrer()
    {
        Iscorrer = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        //Controlar el detector del shift para que la recuperación funcione aunque se presione dicho boton
        //velocidadAtual = Iscorrer ? velCorrer : velocidad;
        velocidadActual = velocidad;

        if (Iscorrer && (movimientoX != 0 || movimientoY != 0) && SaludJugador.instance.estamActual > 0)
        //if (Iscorrer && ((movimientoX > 0 & movimientoY > 0) || (movimientoX > 0 || movimientoY > 0)) && SaludJugador.instance.estamActual > 0)
        {
            //Debug.Log("Condicion 1 cansado es = " + cansado);
            if (!cansado)
            {
                cronomRecuEstamina = 0;
                velocidadActual = velCorrer;
                SaludJugador.instance.GastarEstamina();
            }
            if (SaludJugador.instance.estamActual <= 0)
            {
                //Debug.Log("Punto cansancio del cansancio");
                cansado = true;
                recuperado = false;
                cronomRecuEstamina = 0;
            }
        }
        else if ((!Iscorrer || Iscorrer) && ((movimientoX != 0 || movimientoY != 0) ||
            (movimientoX != 1 || movimientoY != 1)) &&
            (SaludJugador.instance.estamActual < SaludJugador.instance.estamina))
        {
            //Debug.Log("Condicion 2 cansado es = " + cansado);
            if (cansado)
            {
                recuperado = false;

                if (cronomRecuEstamina <= tiempoRecuperacion)
                {
                    cronomRecuEstamina += 1 * Time.deltaTime;
                    //Debug.Log("Preparando carga de estamina" + cronomRecuEstamina);
                }
                else
                {
                    recuperado = true;
                    cansado = false;
                }
            }
        }
        if ((!Iscorrer || cansado || recuperado) && (SaludJugador.instance.estamActual < SaludJugador.instance.estamina))
        {
            //Debug.Log("Condicion 3 cansado es = " + cansado);
            velocidadActual = velocidad;
            //Debug.Log("Aumento de estamina met2");
            SaludJugador.instance.RecuperarEstamina();
        }
    }
    private void Salto()
    {
        rb.AddForce(Vector3.up * fuerzaDeSalto);
        salto = false;
    }

    void Animacion()
    {
        if (salto)
        {
            animator.SetBool("Saltar", true);
            Salto();
        }
        else
        {
            animator.SetBool("Saltar", false);
        }
    }
    private void OnTriggerEnter(Collider colic)
    {
        if (colic.CompareTag("Ataque"))
        {
            recibeDanio = true;
            Debug.Log("Daño");
        }
        recibeDanio = false;
    }

    public void Ray()
    {
        //Para añadir un compoenente visual que me permita ver el tamño del rayo
        Debug.DrawRay(posicionRayo.position, Vector3.down * rayLengt, Color.red);
        //Para verificar que el personaje está tocando el suelo
        enSuelo = Physics.Raycast(posicionRayo.position, Vector3.down, rayLengt, capaSuelo);
    }


}
