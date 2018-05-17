using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Guia de Compreensão: (8/10)

public class ObjectsManager : MonoBehaviour
{//o código abaixo servirá para controlar os objetos que podem ser interagidos em cada sprite.
 //sem ele, o zoom que eu dou em um sprite X poderia ser dado da mesma forma em um sprite y

    private DisplayImage currentDisplay;

    public GameObject[] ObjectsToManage;
    public GameObject[] UIRenderObjects;
    public bool[] BoolTrigger; // Serve para fazer a leitura dos triggers, precisa testa com os objetos em si (INCOMPLETO)

	
	void Start ()
    {
        //pega o script DisplayImage, do GO Display Image, para monitorar a tela que esta selecionada
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        RenderUI();


    }
	
	// Update is called once per frame
	void Update ()
    {
        ManageObjects();
        CheckTrigger();
	}

    void ManageObjects()//ele avaliará os objetos que estão na cena e determinar quais estão ativos (COMPLETO)
    {
        for(int i=0;i<ObjectsToManage.Length; i++)
        {
            //no caso abaix, SE o nome do objeto for o mesmo do sprite que esta selecionado no currentDisplay,
            //significa que o Objeto deve estar atijo para que possa haver interação.
            if (ObjectsToManage[i].name== currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                ObjectsToManage[i].SetActive(true);
            }
            else //caso contrário.
            {
                ObjectsToManage[i].SetActive(false);
            }
        }
    }

    // esse método inativa todos os objetos interagíveis do jogo, devendo eles serem 
    //acrescidos no inspetor.

    void RenderUI()// Desliga os objetos ao iniciar o jogo (COMPLETO)
    {
        for (int i=0; i< UIRenderObjects.Length; i++)
        {
            UIRenderObjects[i].SetActive(false);
        }
    }


    void CheckTrigger()//verifica quais os objetos foram interagidos e armazena (via true/false) - COMPLETO
    {
        for (int i = 0; i < UIRenderObjects.Length; i++)
        {
            if (UIRenderObjects[i].activeInHierarchy==true)
            {
                BoolTrigger[i] = true;
            }
        }
    }
}
