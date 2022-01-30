using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoSleep.IOC;

public enum InputAction
{
    Space_Down, Space_Up,
    W_Down, W_Up,
    S_Down, S_Up,
    A_Down, A_Up,
    D_Down, D_Up,
    R_Down, R_Up,
    Esc_Down, Esc_Up,
    LClick_Down, LClick_Up,
    RClick_Down, RClick_Up
}

public class InputListener : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        ButtonDowns();
        ButtonUps();
    }

    void ButtonDowns()
	{
        //if (Input.GetButtonDown("Jump")) { Signals.Get<Sig_Input_Space>().Dispatch(InputAction.Space_Down); }
        //if (Input.GetButtonDown("Jump")) { Signals.Get<Sig_Input_W>().Dispatch(InputAction.W_Down); }
        //if (Input.GetButtonDown("Jump")) { Signals.Get<Sig_Input_S>().Dispatch(InputAction.S_Down); }
        //if (Input.GetButtonDown("Jump")) { Signals.Get<Sig_Input_A>().Dispatch(InputAction.A_Down); }
        //if (Input.GetButtonDown("Jump")) { Signals.Get<Sig_Input_D>().Dispatch(InputAction.D_Down); }
        //if (Input.GetButtonDown("Jump")) { Signals.Get<Sig_Input_R>().Dispatch(InputAction.R_Down); }
        //if (Input.GetButtonDown("Jump")) { Signals.Get<Sig_Input_Esc>().Dispatch(InputAction.Esc_Down); }
        //if (Input.GetButtonDown("Jump")) { Signals.Get<Sig_Input_LClick>().Dispatch(InputAction.LClick_Down); }
        //if (Input.GetButtonDown("Jump")) { Signals.Get<Sig_Input_RClick>().Dispatch(InputAction.RClick_Down); }
    }

    void ButtonUps()
	{
        //if (Input.GetButtonUp("Jump")) {
        //    Signals.Get<Sig_Input_Space>().Dispatch(InputAction.Space_Up);
        //}
    }
}
