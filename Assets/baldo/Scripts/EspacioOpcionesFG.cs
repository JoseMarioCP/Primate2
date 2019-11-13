using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EspacioOpcionesFG : MonoBehaviour, IDropHandler
{
    int n;
    static int anterior = 1;
    string name;
    Sprite imagen;
    public GameObject item{
        get{
            if(transform.childCount>0){ // Si este objeto tiene un hijo, regresara el primero
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop (PointerEventData eventData)
    {
        if(!item){ //No hay hijo en este objeto (Slot)

            DragHandlerFG.itemBeingDragged.transform.SetParent (transform); // Al objeto movido se le
                                                                          // asigna como padre este objeto
            CreaFigura();

            Destroy(DragHandlerFG.itemBeingDragged);
            CrearObjeto(name, imagen); // Recoge el nombre y sprite del objeto jalado para crear uno nuevo
        }
        else{
            //CrearObjeto(DragHandler.itemBeingDragged.name, DragHandler.itemBeingDragged.GetComponent<Image>().sprite); // Recoge el nombre y sprite del objeto jalado para crear uno nuevo
            //Destroy(DragHandlerFG.itemBeingDragged);
        }
    }

    public void CrearObjeto(string nombre, Sprite figura)  // Volver a crear objeto cuando llega al ejercicio
    {
        GameObject newObject = new GameObject(nombre);   // Se asigna nombre al nuevo objeto
        newObject.AddComponent<Image>();    // Se añade script de imagen
        newObject.AddComponent<DragHandlerFG>();  //Se le agregan scripts
        newObject.AddComponent<CanvasGroup>();
        newObject.transform.SetParent(DragHandlerFG.padre); // Se le da un objeto padre
        newObject.GetComponent<Image>().sprite = figura;    // Se le da un nuevo Sprite
        newObject.GetComponent<Image>().preserveAspect = true;
        newObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
    }

    public void CreaFigura(){
        anterior = n;
        if(anterior==0)
            anterior=1;
        n = Random.Range(1,5);
        
        while(anterior==n)
        {
            n = Random.Range(1,5);
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
    }
}
