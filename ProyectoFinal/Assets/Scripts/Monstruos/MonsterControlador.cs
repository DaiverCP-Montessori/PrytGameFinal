using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterControler : MonoBehaviour
{   
    //Movimiento patrulla
    Transform[] transforms;
    Vector3[] puntosMov;
    Vector3 postMov;
    

    Rigidbody rb;
    public float Radiodeteccion = 5f;


    public Quaternion angulo;
    
    public float cronometro;
    public int rutina;
    public float grado;
    public float velocidad = 1f;
    public bool atacar;

    GameObject player;
    Animator ani;
    
    //Variables ante la deteccion
    public float speedRotacion = 10f;
    public float rayLength = 6f;
    RaycastHit toque;
    LayerMask jugador; 




    void Awake()
    {
        /*
        puntosMov = new Vector3[transforms.Length];
        for (int i = 0; i < puntosMov.Length; i++)
        {
            puntosMov[i] = transforms[i].position;
        }
        postMov = puntosMov[0];*/
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        player = GameObject.Find("Player");
        jugador = LayerMask.GetMask("Player");
    }
    void Update()
    {
        Comportamiento_enemigo();
    }
    void Animacion()
    {

    }

    public void Comportamiento_enemigo()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > Radiodeteccion)
        {
            ani.SetBool("correr", false);
            //Contador por segundos
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                //Opciones Random por numero entre el rango 0 - 2
                rutina = Random.Range(0, 2);
                //reinicio del cronometro
                cronometro = 0;
            }
            //Metodo de donde se encuentran dichas acciones al azar
            AccionesATomar(rutina);
        }
        else
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 1 && !atacar)
            {
                RaycastHit hit;
                Vector3 direction = player.transform.position - transform.position;
                direction.y = 0; // Aseguramos que sea horizontal

                //Trazamos en rayo que irá en la direccion indicada junto con el tamaño y el color que establezcmos de ella
                Debug.DrawRay(transform.position, direction.normalized * rayLength, Color.red);

                //Trazamos el rayo comenzando desde la posicion del monstruo la direccion indicada por la varibale "direccion", con el
                //proposito de que toque el rayo al objeto e indicamos a que capa de que objeto queremos que toque
                if (Physics.Raycast(transform.position, direction.normalized,out hit, rayLength, jugador))
                {
                    //Y si el objeto con el cual llega a chocar el rayo coincide con el objeto indicadada ejecutará lo demás
                    if (hit.collider.gameObject == player)
                    {
                        //Indicamos la posicion del personaje
                        var lookPos = player.transform.position - transform.position;
                        lookPos.y = 0;
                        //Variable que me permite que el personaje solo rote de manera horizontal 
                        var rotation = Quaternion.LookRotation(lookPos);
                        //Giraremos el personaje según el angulo indicado de rotation, aplicandolo al transform rotation del monstro
                        //y lo giramos a una velocidad de 10
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, speedRotacion);
                        /*Me permite localizar el objetivo y se mueve hasta el jugador, eviatando que se vaya en otra dirección*/
                        Vector3 playerLocate = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                        rb.MovePosition(Vector3.MoveTowards(transform.position, playerLocate, velocidad * Time.deltaTime));
                        ani.SetBool("Caminar", false);
                        ani.SetBool("correr", true);
                        ani.SetBool("atacar", false);
                    }
                }
               
            }
            else
            {
                ani.SetBool("Caminar", false);
                ani.SetBool("correr", false);
                
                atacar = true;
                ani.SetBool("atacar", true);
                
            }
        }
    }

    private void AccionesATomar(int rutina)
    {
        switch (rutina)
        {
            case 0:
                ani.SetBool("Caminar", false);
                break;
            case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                //transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
                //Mirar y corregir después
                //
                rb.MovePosition(transform.position + transform.forward * velocidad * Time.deltaTime);

                ani.SetBool("Caminar", true);
                break;
        }
    }



    public void Atacar()
    {
        ani.SetBool("atacar", false);
        atacar = false;
    }

    
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radiodeteccion);
    }

}
