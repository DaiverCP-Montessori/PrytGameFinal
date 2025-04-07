using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    [Tooltip("Locks the rotational up axis of the billboard.")]
    public bool lockUpAxis = true;
    private Camera Mycamera;

    // Start is called before the first frame update
    void Start()
    {
        Mycamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (lockUpAxis)
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, Mycamera.transform.eulerAngles.y + 180, gameObject.transform.eulerAngles.z);
        }
        else {
            gameObject.transform.LookAt(Mycamera.transform.position);
        }
    }
}
