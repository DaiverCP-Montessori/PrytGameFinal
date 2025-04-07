using NUnit.Framework.Constraints;
using UnityEngine;

public class MonsterControler : MonoBehaviour
{   
    //Movimiento patrulla
    Transform[] transforms;
    Vector3[] puntosMov;
    Vector3 postMov;
    

    Rigidbody rb;
    public float detectionRadius = 3f;


    public Quaternion angulo;
    public Animator ani;
    public float cronometro;
    public int rutina;
    public float grado;
    public float velocidad = 1f;
    public bool atacar;
    GameObject player;




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
        if (Vector3.Distance(transform.position, player.transform.position) > 5)
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
        else
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 1 && !atacar)
            {
                //Indicamos la posicion del personaje
                var lookPos = player.transform.position - transform.position;
                lookPos.y = 0;
                //Variable que me permitirá indicar donde o hasta donde rotar el personaje enemigo
                var rotation = Quaternion.LookRotation(lookPos);
                //Giraremos el personaje según el angulo indicado de rotation, aplicandolo al transform rotation del monstro
                //y lo giramos a una velocidad de 5

                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 5);
                ani.SetBool("Caminar", false);
                ani.SetBool("correr", true);

                Vector3 playerLocate = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                rb.MovePosition(Vector3.MoveTowards(transform.position,  playerLocate, velocidad * Time.deltaTime));
                ani.SetBool("atacar", false);
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

    public void Atacar()
    {
        ani.SetBool("atacar", false);
        atacar = false;
    }

    private void OnTriggerEnter(Collider colic)
    {
        if (colic.CompareTag("Ataque"))
        {
            print("Daño");
        }
    }
    /*
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }*/

}
