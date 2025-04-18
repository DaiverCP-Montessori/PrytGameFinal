  using UnityEngine;

public class InteractuarObjeto : MonoBehaviour
{
    public void ActivarObjeto()
    {

        if (transform.parent == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
        
    }

    //Sirve para poner con animacion
    /*
     * public virtual IEnumerator ActivarObjeto()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(transform.parent.gameObject);
    }
     */
}
