using UnityEngine;
using System.Collections;
using System;

//Guia de Compreensão: (5/10)

public class ZoomInObject : MonoBehaviour, IInterectable
{//código utilizado para dar zoom em um objeto que for interagível
    public float ZoomRatio = 0.5f;

    //o método abaixo é executado a partir do código Interact. Quando ele é chamado, aplica zoom no objeto
    public void Interact(DisplayImage currentDisplay) //COMPLETO
    {
        //calcula o tamanho da amplitude câmera;
        Camera.main.orthographicSize *= ZoomRatio;

        //aplica o zoom, com base no GO que foi clicado pelo usuário.
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            Camera.main.transform.position.z);
        gameObject.layer = 2; //altera o layer do objeto que esta interagindo, de forma que ignorará Raycasts
        currentDisplay.CurrentState = DisplayImage.State.zoom;//muda o estado do display image

        //abaixo chamamos um método que restringe o zoom da câmera até o termino da tela. A ideia é evitar
        //que o jogador dê zoom em uma área fora da tela do jogo.
        ConstrainCamera();
    }

    void ConstrainCamera() //restringe o campo de zoom que o jogo pode ter, que seria o limite da tela. (COMPLETO)
    {
        var height = Camera.main.orthographicSize; //define a altura da câmera
        var width = height * Camera.main.aspect;//define largura

        var cameraBounds = GameObject.Find("cameraBounds"); //o GO cameraBounds é quem fará o controle do limite
        //de zoom. Ele terá um box collider limitando a região onde o jogador poderá dar zoom.

        //a condição abaixo significa que, por conta do zoom, a câmera principal passa a mostrar um região fora 
        //da tela. Assim, as condições abaixo corrigem ese problema, limitando até a borda.

        if (Camera.main.transform.position.x + width > cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
        {
            //readequa a posição da câmera principal.
            Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 -
                (Camera.main.transform.position.x + width),0,0);
        }
        if (Camera.main.transform.position.x - width < cameraBounds.transform.position.x - cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
        {
            //readequa a posição da câmera principal.
            Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x - cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 -
                (Camera.main.transform.position.x - width), 0, 0);
        }

        if (Camera.main.transform.position.y + height > cameraBounds.transform.position.y + cameraBounds.GetComponent<BoxCollider2D>().size.y / 2)
        {
            //readequa a posição da câmera principal.
            Camera.main.transform.position += new Vector3(0, cameraBounds.transform.position.y + cameraBounds.GetComponent<BoxCollider2D>().size.y / 2 -
                (Camera.main.transform.position.y + height), 0);
        }
        if (Camera.main.transform.position.y - height < cameraBounds.transform.position.y - cameraBounds.GetComponent<BoxCollider2D>().size.y / 2)
        {
            //readequa a posição da câmera principal.
            Camera.main.transform.position += new Vector3(0, cameraBounds.transform.position.y - cameraBounds.GetComponent<BoxCollider2D>().size.y / 2 -
                 (Camera.main.transform.position.y - height), 0);
        }
    }

}
