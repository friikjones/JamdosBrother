using System;
using System.Collections.Generic;
using UnityEngine;

//Guia de compreensão: (3/10)

//a idéia desse código aqui precisa ser discutida.
//De acordo com o tutorial, todos os GO's "interagíveis" será feito através dessa interface (video 2-15:00).

public interface IInterectable 
{
    void Interact(DisplayImage currentDisplay);
}