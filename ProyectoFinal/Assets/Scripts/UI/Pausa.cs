using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{

    public static Pausa instance;
    public GameObject PantallaPausa;
    public bool escenaPausada;

    void Awake()
    {
        escenaPausada = false;
    }
    void Start()
    {
        if (PantallaPausa != null)
        {
            PantallaPausa.SetActive(false);
            
        }
        if (instance == null)
        {
            instance = this;
        }

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (escenaPausada)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }


    public void Pausar()
    {
        PantallaPausa.SetActive(true);
        escenaPausada = true;

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Reanudar()
    {
        PantallaPausa.SetActive(false);
        escenaPausada = false;

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void IrAlMenu(string NombreMenu)
    {
        //No olvidar poner en el botón de volver al menu el nombre de la escena del menú
        SceneManager.LoadScene(NombreMenu);
    }

}
