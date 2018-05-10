using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Guia de compreensão, seguir uma ordem dos códigos para entender o que foi feito: (1/10)

public class DisplayImage : MonoBehaviour
{//o código abaixo será necessário para fazer a navegação entre as telas que compoem a escape room

    //o código abaixo determina uma característia DA CLASSE DisplayImage, por isso da ausência do parentese,
    //ou seja, não corresponde, necessariamente à um metodo.

    private int currentWall;
    private int previousWall;

    //abaixo, será feito um código que mudará o estado do layer vinculado ao DisplayImage (GO), de forma que ele
    //ignore novos raycasts, o que faz com que o jogador só possa dar um zoom por vez no jogo

    public enum State
    {
        normal,zoom, changeView //seta os estados do enumerador State
    };

    public State CurrentState { get; set; } //atua como um modificado do estado (normal/zoom)
    

    void Start()
    {
        //seto valores iniciais para as variáveis de forma que o if no update seja executa, carregando a tela desejada,
        //no caso a tela 1
        previousWall = 0;
        currentWall = 1;
    }

     void Update()
    {
        //caso esse if seja verdadeiro, significa que alteramos o currentWall, ou seja, pressionamos um dos botões
        if (currentWall!= previousWall)
        {
            //pega o componente SpriteRenderer vinculado a este GO (displayImage) e carrega a tela correspondente
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.ToString());
        }
        //iguala os valores da variável, de forma que o if só sera executado quando o botao for pressionado
        previousWall = currentWall;
    }
    
    //Abaixo, componente da classe Display Image, que faz o controle da numeração da variável currentWall
    //ela será chamada toda vez que o script "ButtonHandler" for executado. Ou seja,
    //quando um dos botoes for pressionado, haverá uma alteração no valor da variável CurrentWall e o código 
    //abaixo transporta essa numeração para a variável currentWall aqui, alterando a tela.

    public int CurrentWall
    {
        get { return currentWall; } //pega do Game Object qual o valor do currentWall
        set{//analisa o input do jogador, pelas setas e atua na mudança da imagem que esta no display.
            if(value == 5)
            {
                currentWall = 1; //volta para a primeira tela.
            }
            else if (value == 0)
            {
                currentWall = 4; //vai para a última tela
            }
            else
            {
                currentWall = value;
            }
        }
        
    }


    
}
