using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Guia de Compreensão: (4/10)

public class Interact : MonoBehaviour
{
    //esse código servirá para cada GO interagível no cenário. No caso, ao usuário clicar em cima de um item
    //por exemplo uma gaveta, o código lançará um raycast e caso o objeto for interagível
    //a câmera irá dar um Zoom

    private DisplayImage currentDisplay;
    
	
	void Start ()
    {//procura o GO Display Image, que detém a classe DisplayImage
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();	
	}
	
	void Update ()
    {// eu devo verificar se o botão esquerdo foi pressionado

        if (Input.GetMouseButtonDown(0))
        {
            //cria um vetor 2D (x,y) raycast a partir do ponto onfde foi clicado pelo mouse
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //usando a classe RaycastHit2D, lança um raycast na cena e verifica se ele colide com algum GO,
            //no caso, o GO precisa ter um box collider para ser percebido pelo raycast
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 1000);
            if(hit && hit.transform.tag == "Interactable") //se o objeto for interagível
            {
                //executa o método Interact, vinculado ao objeto que é interagivel (ver o código Zoom In)
                hit.transform.GetComponent<IInterectable>().Interact(currentDisplay); 
            }
        }
		
	}
}
