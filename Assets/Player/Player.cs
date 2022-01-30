using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NoSleep.IOC;

[Dock] public class Player : MonoBehaviour
{
    public enum PlayerState { Body, Spirit, Dead };

    [Header("Game Scene References")]
    public GameObject body;
    public Camera bodyCamera;
    public GameObject spirit;
    public Camera spiritCamera;

    [Header("Status Variables")]
    public PlayerState State = PlayerState.Body;
    public int MaxHealth;
    public int CurrentHealth;
    public int MaxMana;
    public int CurrentMana;

    [Header("Movement Variables")]
    public float moveThrust;
    public float jumpThrust;
    public Vector2 maxVelocity;

    // Internal References
    [Dock] private GameManager gameManager;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveDir = Vector2.zero;

    /// <summary>
    /// Gameobject reference to the currently active body to manipulate for movement. Toggles between body and spirit.
    /// </summary>
    private GameObject activeBody;
    private Camera activeCamera;


    #region Unity Lifecycle Methods
    private void Start()
    {
        activeBody = body;
        rb = activeBody.GetComponent<Rigidbody2D>();
        anim = activeBody.GetComponentInChildren<Animator>();
        activeCamera = activeBody.GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        HandleInput();
        Move();
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		
	}

	private void OnDestroy()
	{

    }
	#endregion

	private void HandleInput()
	{
        // Assemble WSAD Vector. No y movement currently.
        int x = 0, y = 0;
        x += gameManager.activeKeyboard.dKey.isPressed == true ? 1 : 0;
        x -= gameManager.activeKeyboard.aKey.isPressed == true ? 1 : 0;
        // y += gameManager.activeKeyboard.wKey.isPressed == true ? 1 : 0;
        // y -= gameManager.activeKeyboard.sKey.isPressed == true ? 1 : 0;
        moveDir = new Vector2(x, y);

        // Attempt other actions.
        if (gameManager.activeKeyboard.spaceKey.wasPressedThisFrame) { Jump(); }
        if (gameManager.activeKeyboard.rKey.wasPressedThisFrame) { SwitchForm(); }
        if (gameManager.activeMouse.leftButton.wasPressedThisFrame) { Attack(); }
    }

    private void Move()
	{
        if (moveDir.x != 0 || moveDir.y != 0) {
            rb.AddForce(moveDir * moveThrust);
		}

        if (rb.velocity.x > maxVelocity.x) {
            rb.velocity = new Vector2(maxVelocity.x, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxVelocity.x) {
            rb.velocity = new Vector2(-maxVelocity.x, rb.velocity.y);
        }
        // Don't clamp positive y velocity for now.
        //if (rb.velocity.y > maxVelocity.y) {
        //    rb.velocity = new Vector2(rb.velocity.x, maxVelocity);
        //}
        if (rb.velocity.y < -maxVelocity.y) {
            rb.velocity = new Vector2(rb.velocity.x, -maxVelocity.y);
        }

        anim.SetFloat("xVel", rb.velocity.x);
    }

    private void Jump()
	{
        rb.AddForce(Vector2.up * jumpThrust);
	}

    private void SwitchForm()
	{
        switch(State)
		{
            case PlayerState.Body:
                rb.velocity = Vector2.zero;
                activeBody = spirit;
                activeBody.transform.position = body.transform.position;
                activeBody.SetActive(true);
                spiritCamera.gameObject.SetActive(true);
                bodyCamera.gameObject.SetActive(false);
                State = PlayerState.Spirit;
                break;
            case PlayerState.Spirit:
                rb.velocity = Vector2.zero;
                activeBody.SetActive(false);
                activeBody.transform.position = body.transform.position;
                activeBody = body;
                bodyCamera.gameObject.SetActive(true);
                spiritCamera.gameObject.SetActive(false);
                State = PlayerState.Body;
                break;
            case PlayerState.Dead:
                return;
        }

        rb = activeBody.GetComponent<Rigidbody2D>();
        anim = activeBody.GetComponentInChildren<Animator>();
        activeCamera = activeBody.GetComponentInChildren<Camera>();
    }

    private void Attack()
	{

	}
}
