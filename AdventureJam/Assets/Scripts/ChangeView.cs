using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Guia de Compreensão: (7/10)

public class ChangeView : MonoBehaviour, IInterectable
{
    //o código servirá para dar foco em um ponto específico da cena, por exemplo em cima da mesa.
    //Cabe ressaltar que, nesse contexto, o sistema será Interactable, motivo pelo qual precisamos acrescentar
    //a interface IInterectable (errei a digitação aqui), além da biblioteca Systema lá em cima.

    public string SpriteName;

    public void Interact(DisplayImage currentDisplay) //(COMPLETO)
    {
        //ao interagir com o GO, ele irá puxar a cena específica do close desejado.
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + SpriteName);
        currentDisplay.CurrentState = DisplayImage.State.changeView;
    }

}
