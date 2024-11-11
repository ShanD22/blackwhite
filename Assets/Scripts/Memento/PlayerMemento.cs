using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMemento 
{
    public Vector3 Position {  get; private set; }
    public Istate checkpointState;

    public PlayerMemento(Vector3 position, Istate state)
    {
        Position = position;
        checkpointState = state;
    }

}
