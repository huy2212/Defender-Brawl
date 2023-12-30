using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurnable
{
    public bool CanTurn { get; set; }
    public void TurnForward();
    public void TurnBackward();
}
