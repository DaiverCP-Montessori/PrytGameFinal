using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
   TextMeshProUGUI textoMonedas;
   public static ManagerUI instance;
   int monedasNuevas = 0;
   int monedasActuales;
   void Awake()
   {
        if(instance == null)
        {
            instance = this;
        }

        textoMonedas = GetComponent<TextMeshProUGUI>();
    }

   public void AniadirMoneda(int NuevaCantidad)
   {
        monedasNuevas += NuevaCantidad;
        ActualizarMonedas();
        monedasNuevas = 0;
   }

    void ActualizarMonedas()
    {
        monedasActuales = int.Parse(textoMonedas.text.Split(' ')[1]);
        monedasActuales += monedasNuevas;
        textoMonedas.text = "x " + monedasActuales;

    }
   

   public void GastarMonedas(int CantidadAGastar)
   {

   }
    
}
