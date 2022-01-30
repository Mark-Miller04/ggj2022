using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NoSleep.IOC;

[Dock] public class GameManager : MonoBehaviour
{
    [Dock] private Player player;

    // Input Devices
    public Keyboard activeKeyboard;
    public Mouse activeMouse;
    public Gamepad activeGamepad;

    #region Unity Lifecycle Methods
    void Start()
    {
        RefreshInputDevices();
    }

    void Update()
    {
        HandleInput();
    }
    #endregion

    private void RefreshInputDevices()
	{
        activeKeyboard = Keyboard.current;
        activeMouse = Mouse.current;
        activeGamepad = Gamepad.current;
	}

    private void HandleInput()
	{
        if (activeKeyboard.escapeKey.isPressed) { Pause(); }
    }

    private void Pause()
	{

	}
}
