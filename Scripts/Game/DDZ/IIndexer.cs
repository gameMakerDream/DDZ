using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIndexer
{
    public int seatIndex { get; set; }
    public void Initialize(int seatIndex);
}
