using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WhiteState : Istate
{
    public PlayerController player;
    public Player_WhiteState(PlayerController player)
    {
        this.player = player;
    }

    public  void EnterState()
    {
    
        player.currentPlayerColor = player.playerScriptableWhite.Color;
        player.sprR.color = player.currentPlayerColor;
        Debug.Log("Color set to white");

        player.coll.excludeLayers -= player.blackLayer;
    }

    public void ExitState()
    {
        player.coll.excludeLayers += player.blackLayer;
        Debug.Log("Exitting state");
    }

    public void UpdateState()
    {

    }


}
