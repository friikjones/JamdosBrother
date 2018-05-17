using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideSolutions : MonoBehaviour
{
     //esse código serve para esconder as soluções, caso o jogador tenha apertado o botão "solução"
     //mas tenha clicado fora.

    private GameObject rightArrow;
    private GameObject leftArrow;


    // Update is called once per frame
    void Update()
    {
        rightArrow = GameObject.Find("buttonRight");
        leftArrow = GameObject.Find("buttonLeft");
        HideDisplayItem();
    }

    void HideDisplayItem() //INCOMPLETO 
    {
        //caso o jogador clique fora do objeto.
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }
    }
}
