using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanel
{
    GameObject animationRoot { get;}

    void Show(bool immediately=false);
    void Hide(bool immediately=false);
}
