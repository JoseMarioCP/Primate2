using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ValidaSlots : MonoBehaviour
{
    public Musica sonidos;
    GameObject puntosObjeto;
    static int puntosNumero = 0;

    static int intentos = 0;

    public Puntos_Contar puntos;

    public GameObject canvasJuego;
    public GameObject canvasFinal;


    // Update is called once per frame
    void Update()
    {
        ChecaSolts();
        Calificar();
    }

    private void Start() {
        puntosObjeto = GameObject.Find("opcion_puntos");
    }
    public void ChecaSolts(){
        //gameObject.name; //se obtiene el gameobject del que esta actuando
        switch(gameObject.name){
            case "SlotCirculo":
                    if(transform.childCount>0){ // Si este objeto tiene un hijo, regresara el primero
                        if(transform.GetChild(0).gameObject.name == "circulo"){
                            //Debug.Log("Correcto en Circulo");
                            IncrementarPuntos();
                        }
                        else{
                            DecrementarPuntos();
                        }
                    }
                break;

            case "SlotCuadrado":
                    if(transform.childCount>0){ // Si este objeto tiene un hijo, regresara el primero
                        if(transform.GetChild(0).gameObject.name == "cuadrado"){
                            //Debug.Log("Correcto en Cuadrado");
                            IncrementarPuntos();
                        }
                        else{
                            DecrementarPuntos();
                        }
                    }
                break;

            case "SlotRectangulo":
                    if(transform.childCount>0){ // Si este objeto tiene un hijo, regresara el primero
                        if(transform.GetChild(0).gameObject.name == "rectangulo"){
                            //Debug.Log("Correcto en Rectangulo");
                            IncrementarPuntos();
                        }
                        else{
                            DecrementarPuntos();
                        }
                    }
                break;

            case "SlotTriangulo":
                    if(transform.childCount>0){ // Si este objeto tiene un hijo, regresara el primero
                        if(transform.GetChild(0).gameObject.name == "triangulo"){
                            //Debug.Log("Correcto en Triangulo");
                            IncrementarPuntos();
                        }
                        else{
                            DecrementarPuntos();
                        }
                    }
                break;
        }
    }

    public void IncrementarPuntos(){
        puntosNumero++;
        intentos++;
        puntos.incrementarPuntos();
        puntosObjeto.GetComponent<UnityEngine.UI.Text>().text = puntosNumero.ToString();
        sonidos.Correcta();
    }

    public void DecrementarPuntos(){
        puntosNumero--;
        intentos++;
        puntos.decrementarPuntos();
        puntosObjeto.GetComponent<UnityEngine.UI.Text>().text = puntosNumero.ToString();
        sonidos.Incorrecta();
    }

    public void Calificar(){
        if(intentos >= 10){
            puntos.Calificar();
            canvasJuego.SetActive(false);
            canvasFinal.SetActive(true);
            puntosNumero = 0;
            intentos = 0;
            puntosObjeto.GetComponent<UnityEngine.UI.Text>().text = "Ganaste!!";
        }
    }
}
