using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanel
{
    void Show(bool immediately=false);
    void Hide(bool immediately=false);
    void Update(object data);
}
