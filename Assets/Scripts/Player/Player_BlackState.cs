using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BlackState : Istate
{
    PlayerController player;
    public Player_BlackState(PlayerController player)
    {
        this.player = player;
    }
    public void EnterState()
    {
       
        player.currentPlayerColor = player.playerScriptableBlack.Color;
        player.sprR.color = player.currentPlayerColor;  
        Debug.Log("Color set to black");

        player.coll.excludeLayers += player.whiteLayer;
    }

    public void ExitState()
    {

        player.coll.excludeLayers -= player.whiteLayer;
        Debug.Log("Exiting state");
    }

    public void UpdateState()
    {
    }

}
