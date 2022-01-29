using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoSleep.IOC;

public enum InputAction
{
    SpaceDown, SpaceUp,

}

public class InputListener : MonoBehaviour
{
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            Debug.Log("Pressed space!");
            Signals.Get<Sig_Input_Space>().Dispatch(InputAction.SpaceDown);
		}

        if (Input.GetButtonUp("Jump")) {
            Debug.Log("Released space!");
            Signals.Get<Sig_Input_Space>().Dispatch(InputAction.SpaceUp);
        }
    }
}
