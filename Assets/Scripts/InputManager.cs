using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputName
{
    public static string key_a = "a";
    public static string key_z = "z";
    public static string key_e = "e";
    public static string key_r = "r";
    public static string key_t = "t";
    public static string key_y = "y";
    public static string key_u = "u";
    public static string key_i = "i";
    public static string key_o = "o";
    public static string key_p = "p";
    public static string key_q = "q";
    public static string key_d = "d";
    public static string key_f = "f";
    public static string key_g = "g";
    public static string key_h = "h";
    public static string key_j = "j";
    public static string key_k = "k";
    public static string key_l = "l";
    public static string key_m = "m";
    public static string key_w = "w";
    public static string key_x = "x";
    public static string key_c = "c";
    public static string key_v = "v";
    public static string key_b = "b";
    public static string key_n = "n";
    public static string leftDirection = "LeftDirection";
    public static string rightDirection = "RightDirection";
    public static string jump = "Jump";
}

public class InputManager : MonoBehaviour {

    public static bool IsDown (string inputName)
    {
        return Input.GetButtonDown(inputName);
    }

    public static bool IsHeld(string inputName)
    {
        return Input.GetButton(inputName);
    }

    public static bool IsUp(string inputName)
    {
        return Input.GetButtonUp(inputName);
    }

    public static bool MouseButtonDown ()
    {
        return Input.GetMouseButtonDown(0);
    }

}
