using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager instance;
    public static CheckpointManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CheckpointManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("CheckpointManager");
                    instance = obj.AddComponent<CheckpointManager>();
                }
            }
            return instance;
        } 

    }

    private List<PlayerMemento> checkpoints = new List<PlayerMemento>();    
    public int checkpointCount => checkpoints.Count;

    public void AddCheckpoint(PlayerController player, Istate state)
    {
        player.SavePosition();
        checkpoints.Add(player.CreateMemento(state));
    }

    public void RestoreCheckpoint(PlayerController player)
    {
        PlayerMemento mementoToRestore = checkpoints[checkpoints.Count - 1];
        player.RestoreMemento(mementoToRestore);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Debug.Log(checkpointCount);
    }
}
