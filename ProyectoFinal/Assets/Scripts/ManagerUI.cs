using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    static public int cantidadMonedas = 0;


   void AniadirMoneda(int NuevaCantidad)
    {
        cantidadMonedas = cantidadMonedas + NuevaCantidad;
        NuevaCantidad = 0;
    }
}
