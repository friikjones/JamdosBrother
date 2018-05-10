using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Guia de Compreensão: (9/10)

public class UIDisplayer : MonoBehaviour, IInterectable
{
    //esse código é anexado a cada UI/Image que deve aparecer quando interagido, sendo necessário um Box Collider
    public GameObject DisplayObject;


    public void Interact(DisplayImage currentDisplay)
    {
        DisplayObject.SetActive(true);
        Debug.Log("teste");
    }
	
}
