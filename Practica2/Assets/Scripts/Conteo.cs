using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conteo : MonoBehaviour
{
    private Button btn;
    public Image img;
    public Sprite[] spNumero;
    public Text texto;
    private bool contar;
    private int numero;

    // Start is called before the first frame update
    void Start()
    {
       btn=GameObject.FindAnyObjectByType<Button>();
       //btn = GameObject.FindWithTag("BtnStart").GetComponent<Button>();
       btn.onClick.AddListener(Pulsado);
       contar = false;
       numero = 3;
    }

    void Pulsado(){

        img.gameObject.SetActive(true);
        btn.gameObject.SetActive(false);
        contar = true;

    }
    // Update is called once per frame
    void Update()
    {
        if ( contar == true){
            switch (numero)
            {
                case 0: 
                    Debug.Log("Terminado - Salto a otra Escena");
                    break;
                case 1:
                    img.sprite = spNumero[0];
                    texto.text = "" + numero;
                    break;
                case 2:
                    img.sprite = spNumero[1];
                    texto.text = "" + numero;
                    break;
                case 3:
                    img.sprite = spNumero[2];
                    texto.text = "" + numero;
                    break;
                
            }
        
            StartCoroutine(Esperar());
            contar = false;
            numero --;
        }
    }

    IEnumerator Esperar(){
        
        yield return new WaitForSeconds(1);
        contar = true;
    }

}