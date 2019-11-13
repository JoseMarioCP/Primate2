using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CrearFiguraFG : MonoBehaviour
{
    int n;
    public static int anterior = 1;
    string name;
    Sprite imagen;
    void Awake()
    {
        CreaFigura();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start() {
        CrearObjeto(name, imagen);
    }

    public void CreaFigura(){
        n = Random.Range(1,4);

        while(anterior==n)
        {
            n = Random.Range(1,4);
        }

        if(n<=1){
            name = "circulo";
            imagen = Resources.Load<Sprite>("circulo");
        }
        else if(n<=2){
            name = "cuadrado";
            imagen = Resources.Load<Sprite>("cuadrado");
        }
        else if(n<=3){
            name = "rectangulo";
            imagen = Resources.Load<Sprite>("rectangulo");
        }
        else{
            name = "triangulo";
            imagen = Resources.Load<Sprite>("triangulo");
        }

        anterior = n;
    }

    public void CrearObjeto(string nombre, Sprite figura)  // Volver a crear objeto cuando llega al ejercicio
    {
        GameObject newObject = new GameObject(nombre);   // Se asigna nombre al nuevo objeto
        newObject.AddComponent<Image>();    // Se añade script de imagen
        newObject.AddComponent<DragHandlerFG>();  //Se le agregan scripts
        newObject.AddComponent<CanvasGroup>();
        newObject.transform.SetParent(GameObject.Find("SlotOpciones").transform); // Se le da un objeto padre
        newObject.GetComponent<Image>().sprite = figura;    // Se le da un nuevo Sprite
        newObject.GetComponent<Image>().preserveAspect = true;
        newObject.GetComponent<RectTransform>().localScale = new Vector3(1f,1f,1f);
    }
}
