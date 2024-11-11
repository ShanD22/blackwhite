using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    #region Variables
    private Istate currentState;
    [HideInInspector]public Player_BlackState blackState;
    [HideInInspector]public Player_WhiteState whiteState;

    private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;
    private bool canSwitch;
    private float SwitchTimer;


    public Color currentPlayerColor;
    public GameOverManager gameOverManager;

    [Header("Player Data")]
    public Player playerScriptableWhite;
    public Player playerScriptableBlack;

    [Header("Start color")]
    public bool blackStart;

    [Header("Movement")]
    public float moveSpeed;


    [Header("Jump")]
    public float jumpHeight;
    public float castLength;
    public LayerMask whiteLayer;
    public LayerMask blackLayer;
    public int whiteLayerInt;
    public int blackLayerInt;
    private bool isGrounded;

    //EVENTS
    public UnityEvent OnDie;
    public UnityEvent OnTouchCheckpoint;


    //MEMENTO
    private Vector3 currentPosition;


    //RESERVING COMPONENT MEMORY SLOTS
    [HideInInspector] public Transform trns;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public SpriteRenderer sprR;
    public BoxCollider2D coll;

    #endregion

    private void Awake()
    {
        if (OnDie == null)
        {
            OnDie = new UnityEvent();
        }
        if (OnTouchCheckpoint == null)
        {
            OnTouchCheckpoint = new UnityEvent();
        }

        blackState = new Player_BlackState(this);
        whiteState = new Player_WhiteState(this);

        gameOverManager = FindObjectOfType<GameOverManager>();

    }


    void Start()
    {
        #region ACCESSING COMPONENTS
        trns = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sprR = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        #endregion

        

        SwitchTimer = 0f;
        moveSpeed = playerScriptableBlack.MoveSpeed;
        if (blackStart)
        {

            currentState = blackState;
            currentState.EnterState();
        }
        else
        {
            currentState = whiteState;
            currentState.EnterState();
        }
    }


    void Update()
    {
        isGrounded = IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        jumpBufferCounter -= Time.deltaTime;

        JumpHandler();

        SwitchTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && canSwitch && SwitchTimer > .5f)
        {
            SwitchTimer = 0f;   
            SwitchColors();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        currentState?.UpdateState();
    }

    public void ChangeState(Istate newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    Iinteractable interact = collision.GetComponent<Iinteractable>();   
        if (interact != null)
        {
            interact.Interact();
        }
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == whiteLayerInt || collision.gameObject.layer == blackLayerInt)
        {
            canSwitch = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == whiteLayerInt | collision.gameObject.layer == blackLayerInt)
        {
            canSwitch = true;
        } 
    }

    #region MOVEMENT
    //MOVEMENT HANDLING FOR PLAYER
    public void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;

    }

    //JUMP HANDLER
    public void JumpHandler()
    {
        if (IsGrounded() && (jumpBufferCounter > 0))
        {
            Vector2 jumpVector = new Vector2(0, jumpHeight);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(jumpVector,ForceMode2D.Impulse);
            jumpBufferCounter = 0;
        }
    }

    //GROUND CHECK
    public bool IsGrounded()
    {
        Vector2 startPosition = (Vector2)transform.position + new Vector2(0, -coll.size.y / 2); 
        Vector2 size = new Vector2(coll.size.x, 0.1f);


        LayerMask checkMask = 0;
        if (currentState is Player_BlackState)
        {
            checkMask = blackLayer;
        }
        else if (currentState is Player_WhiteState)
        {
            checkMask = whiteLayer;
        }

        RaycastHit2D hit = Physics2D.BoxCast(startPosition, size, 0f, Vector2.down, 0f, checkMask);

        Debug.DrawRay(startPosition, Vector2.down * 0.1f, Color.red);

        return hit.collider != null;
    }
    #endregion

    public void SwitchColors()
    {
        if (currentState is Player_BlackState)
        {
            ChangeState(whiteState);
        }
        else if (currentState is Player_WhiteState)
        {
            ChangeState(blackState);
        }
    }
    public void KillPlayer()
    {
        CheckpointManager.Instance.RestoreCheckpoint(this);
        Debug.Log("Died");
        OnDie.Invoke();
        gameOverManager.ShowGameOver();
    }



    #region Memento

    public void SavePosition()
    {
        currentPosition = transform.position;
    }
    public PlayerMemento CreateMemento(Istate state)
    {
        return new PlayerMemento(currentPosition, state);
    }


    /// <summary>
    /// This function will restore the memento
    /// </summary>
    public void RestoreMemento(PlayerMemento memento)  
    {
        currentPosition = memento.Position;
        ChangeState(memento.checkpointState);
        Debug.Log(currentState);
        transform.position = memento.Position;
    }
    
    #endregion
}
