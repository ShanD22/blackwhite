using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Checkpoint : MonoBehaviour, Iinteractable
{
    private CheckpointManager checkpointManager;
    private PlayerController playerController;
    public bool isTriggered;
    public bool isBlack;
    private Istate state;
    private SpriteRenderer spr;
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();   
        playerController = FindFirstObjectByType<PlayerController>();
        checkpointManager = FindFirstObjectByType<CheckpointManager>();


        if (!isTriggered)
        {
        spr.color = Color.yellow;

        }
        else
        {
            spr.color = Color.green;
        }

        if (isBlack)
        {
            state = new Player_BlackState(playerController);
            Debug.Log(state);
        }

        else
        {
            state = new Player_WhiteState(playerController);
             
            Debug.Log(state);
        }
    }

    public void Interact()
    {
        if (!isTriggered)
        {
        checkpointManager.AddCheckpoint(playerController,state);
        playerController.OnTouchCheckpoint.Invoke();
        isTriggered = true;

        }
        spr.color = Color.green;

    }
}
