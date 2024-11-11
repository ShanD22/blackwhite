using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_KillBarrier : MonoBehaviour, Iinteractable
{

    [SerializeField] private PlayerController playerController; 
    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }
    public void Interact()
    {
    playerController.KillPlayer();

    }
}
