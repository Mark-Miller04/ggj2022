using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using NoSleep.IOC;

[Dock] public class Player : MonoBehaviour
{
    public enum PlayerState { Body, Spirit, Dead };

    [Header("Game Scene References")]
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject spirit;
    [SerializeField] private Camera activeCamera;

    [Header("Status Variables")]
    public PlayerState State = PlayerState.Body;
    public int MaxHealth;
    public int CurrentHealth;
    public int MaxMana;
    public int CurrentMana;

    [Header("Movement Variables")]
    public float jumpThrust;

    // Internal References
    Rigidbody2D rb;

    /// <summary>
    /// Gameobject reference to the currently active body to manipulate for movement. Toggles between body and spirit.
    /// </summary>
    private GameObject activeBody;

    #region Unity Lifecycle Methods
    private void Start()
    {
        Signals.Get<Sig_Input_Space>().AddListener(HandleInput);

        rb = body.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		
	}

	private void OnDestroy()
	{
        Signals.Get<Sig_Input_Space>().RemoveListener(HandleInput);
    }
	#endregion

	private void HandleInput(InputAction act)
	{
        //var keyboard = 

        switch (act)
		{
            case InputAction.Space_Down:
                Jump();
                break;
            case InputAction.Space_Up:
                Debug.Log("And I heard it!");
                break;
        }
	}

    private void Move()
	{

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
                State = PlayerState.Spirit;
                activeBody = spirit;
                break;
            case PlayerState.Spirit:
                State = PlayerState.Body;
                activeBody = body;
                
                break;
            case PlayerState.Dead:
                return;
        }

        rb = activeBody.GetComponent<Rigidbody2D>();
    }
}
