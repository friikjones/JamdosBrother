using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Guia de Compreensão: (2/10)

public class ButtonHandler : MonoBehaviour
{

    private DisplayImage currentDisplay;
    private ObjectsManager triggerManager;
    public GameObject[] solution;


    //as variáveis abaixo são para poder fazer o Zoom Out, que é feito resetando os parâmetros da camera principal
    //e dos GO's que tinham os layers alterados (para ignore Raycast)
    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    void Start()
    {//inicialmente, a variável irá buscar o GO e pegar o script que está atrelado à ela, para poder executar 
     //o CurrentWall e alterar as telas da Escape Room

        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
        triggerManager = GameObject.Find("sceneManager").GetComponent<ObjectsManager>();
        for(int i=0; i < solution.Length; i++)
        {
            solution[i].SetActive(false);
        }
        

    }

    public void OnRightClickArrow()//botão direito pressionado (COMPLETO)
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
    }

    public void OnLeftClickArrow() //botão esquerdo pressionado (COMPLETO)
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnClickSolution() //botão de soluções pressionado (INCOMPLETO)
    {//nesse código aqui, deverá aparecer as oções de solução do caso, de acordo com as interações
     //que o jogador teve ao longo do gameplay.
     
        if (triggerManager.BoolTrigger[1]==true && triggerManager.BoolTrigger[3] == true && 
            triggerManager.BoolTrigger[4] == true )
        {//nesse caso, se o jogador tiver realizado as interações correspondentes à um tipo de solução,
           //essa solução correspondente será visível ao jogador, quando ele clicar em "Solução"    
            solution[1].SetActive(true);
        }
      
        //FALTA FAZER OS OUTROS IF'S QUE CORRESPONDEM ÀS OUTRAS SOLUÇÕES/TRIGGERS
    }

    public void OnClickReturn() //Retorna a tela inicial da cena (COMPLETO)
    {
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            //volta a condição normal o GO Display Image
            GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.normal;
            //agora a ideia é resetar os layers dos GO's

            //no comando abaixo, eu crio uma variável com a lista de todos os GO's do tipo ZoomInObject
            var zoomInObjects = FindObjectsOfType<ZoomInObject>();

            foreach (var zoomInObject in zoomInObjects)
            {
                //o comando abaixo reseta o layer destes GO's para o padrão default, aceitando receber Raycast.
                zoomInObject.gameObject.layer = 0;
            }

            //agora, resetamos as condições da camera

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
        else
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
            currentDisplay.CurrentState = DisplayImage.State.normal;
        }
    }
}
