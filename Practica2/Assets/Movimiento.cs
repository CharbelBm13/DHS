using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Camera camara;
    public int velocidad;
    public GameObject prefabSuelo;
    private Rigidbody rb;

    private Vector3 offset;
    private Vector3 direccionActual;
    private float x;
    private float z;
    // Start is called before the first frame update
    void Start()
    {

        offset = camara.transform.position;
        x=0;
        z=0;
        rb=GetComponent<Rigidbody>();
        direccionActual = Vector3.forward;
        SueloInicial();

    }

    // Update is called once per frame
    void Update()
    {

        camara.transform.position= this.transform.position + offset;
        if(Input.GetKeyUp(KeyCode.Space)){
            if(direccionActual == Vector3.forward){
                direccionActual= Vector3.right;
            }else{
                direccionActual = Vector3.forward;
            }
        }
        float tiempo = velocidad * Time.deltaTime;
        rb.transform.Translate( direccionActual* tiempo);
    }
    void SueloInicial(){
        for(int n = 0 ; n < 3 ; n++){
            z += 6.0f;
            GameObject elsuelo = Instantiate(prefabSuelo, new Vector3(x,0.0f,z),Quaternion.identity) as GameObject;
        }
        

    }
}