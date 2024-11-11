using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public TextMeshProUGUI text;
    private PlayerController playerController;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        text = GetComponent<TextMeshProUGUI>();
        playerController = FindFirstObjectByType<PlayerController>();
        playerController.OnTouchCheckpoint.AddListener(CheckpointGet);
        
    }

    void Update()
    {
        
    }

    public void CheckpointGet()
    {
        text.text = "Checkpoint!";
        animator.Play("WobbleAnim");
        
    }
}
