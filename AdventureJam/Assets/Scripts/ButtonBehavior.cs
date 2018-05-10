using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Guia de Compreensão: (6/10)
public class ButtonBehavior : MonoBehaviour
{//a ideia do código é manipular quando os botões estarão ativos/inativos para cada tipo de situação, 
 //como no zoom.

        public enum ButtonId
    {//controlará os estados dos botões
        roomChangeButton, returnButton
    }

    public ButtonId ThisButtonId;
    private DisplayImage currentDisplay;

	// Use this for initialization
	void Start ()
    {//encontra o GO Display Image, para auxiliar na manipulação das telas
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        HideDisplay();
        Display();
	}

    void HideDisplay()//esconde os botões, de acordo com o estado da tela (zoom,normal)
    {//no if abaixo, a tela esta na condição normal, logo o bitão de retorno não é neessário
        if(currentDisplay.CurrentState==DisplayImage.State.normal && ThisButtonId == ButtonId.returnButton)
        {//constrói um nova cor, no caso, como quero desaparecer com o botão, o valor 0 o torna transparente
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
               GetComponent<Image>().color.b, 0);

            //aqui desabilita o botão
            GetComponent<Button>().enabled = false;

            //muda a ordem de renderização dele no canvas
            this.transform.SetSiblingIndex(0);
        }
        //mesmo código acima, porém, agora é para o caso em que a tela esta no zoom, então não queremos
        //os botões que trocam a tela.
        if (!(currentDisplay.CurrentState == DisplayImage.State.normal) && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 0);

            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
    }

    void Display()//mostra os botões novamente, de acordo com o seu estado
    {
        //nessa condição, habilita o botão de retornar, pois a tela esta no modo zoom ou em change view
        if (!(currentDisplay.CurrentState == DisplayImage.State.normal) && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
               GetComponent<Image>().color.b, 1);

            GetComponent<Button>().enabled = true;
            
        }
        //caso a tela esteja no modo normal, queremos os botões de troca de tela ativo.
        if (currentDisplay.CurrentState == DisplayImage.State.normal && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
               GetComponent<Image>().color.b, 1);

            GetComponent<Button>().enabled = true;

        }
    }
}
