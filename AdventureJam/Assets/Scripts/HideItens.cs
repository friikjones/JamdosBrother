using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Guia de Compreensão: (10/10)

public class HideItens : MonoBehaviour
{

    //esse código é colocado no SceneManager, com o intuito de esconder o UI/Image, após o usuário clicar
    //fora do objeto.

    private GameObject displayImage;

	// Use this for initialization
	void Start ()
    {
        displayImage = GameObject.Find("displayImage");
	}
	
	// Update is called once per frame
	void Update ()
    {
        HideDisplayItem();
	}

    void HideDisplayItem() //(COMPLETO)
    {
        //caso o jogador clique fora do objeto.
        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }

        //essa condição é para que os box colliders de uma dada região (zoom/change view) seja inativados.
       if(displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
       {
           this.gameObject.SetActive(false);
       }
    }
}
