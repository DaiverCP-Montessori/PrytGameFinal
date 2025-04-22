using System;
using UnityEngine;

public class EjecutarDanioPlayer :  MonoBehaviour
{
    private EnvioDanioACaja monstruo;

    void Start()
    {
        monstruo = GetComponentInParent<EnvioDanioACaja>();
    }
    private void OnTriggerEnter(Collider objetoColl)
    {
        if (objetoColl.CompareTag("Player"))
        {
            if (monstruo != null)
            {
                int danio = monstruo.ObtenerDanio();
                SaludJugador.instance.TakeDamage(danio);
            }
        }
    }


}
