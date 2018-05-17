using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Guia de Compreensão: (9/10)

public class UIDisplayer : MonoBehaviour, IInterectable
{
    //esse código é anexado a cada UI/Image que deve aparecer quando interagido, sendo necessário um Box Collider
    public GameObject DisplayObject;
    private string displayImage;

    public string sceneItsIn;

    public void Interact(DisplayImage currentDisplay) //COMPLETO
    {
        DisplayObject.SetActive(true);
       
    }

   

}
