using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Guia de Compreensão: (2/10)

public class ButtonHandler : MonoBehaviour
{

    private DisplayImage currentDisplay;

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

    }

    public void OnRightClickArrow()//botão direito pressionado
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
    }

    public void OnLeftClickArrow() //botão esquerdo pressionado
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnClickReturn()
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
