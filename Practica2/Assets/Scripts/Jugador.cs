using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{

    public float velocidad;
    private Rigidbody rb;
    public Camera camara;
    private Vector3 offset;
    private int vida = 4;
    private int estrella = 0;
    public Text texto;
    private Vector3 PosJugador;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PosJugador = rb.transform.position;
        offset = camara.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        float MovHorizontal = Input.GetAxis("Horizontal");
        float MovVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(MovHorizontal, 0.0f, MovVertical);
        rb.AddForce(movimiento*velocidad);
        camara.transform.position = this.transform.position + offset;
    }

     private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Obs1")){
            Debug.Log("Has Chocado con un Obstaculo");
            vida--;
            texto.text = "Vidas : " + vida;
            rb.transform.position = PosJugador;
        }

        if(vida == 0){
            SceneManager.LoadScene("Escena3", LoadSceneMode.Single); 
        }

        if(other.gameObject.CompareTag("Premio")){ 
            estrella++;
        }

        if(estrella == 1){
            SceneManager.LoadScene("Escena4", LoadSceneMode.Single);     
        }

       
        
    }
}
