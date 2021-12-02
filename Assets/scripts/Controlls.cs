using UnityEngine;
using System.Collections.Generic;

    public static class Utilities
{
    private static Controlls _controlls = new Controlls();
    public static Controlls Controlls => _controlls;
}    

    public class Controlls
    {
    public KeyCode this[string index]
    {
        get
        {
            return _controlls[index];
        }
        set
        {
            _controlls[index] = value;
        }
    }
    
    private static Dictionary<string, KeyCode> _controlls =
        new Dictionary<string, KeyCode>
        {
                { "Upwards", KeyCode.W },
                { "Backwards", KeyCode.S },
                { "Left", KeyCode.A },
                { "Right", KeyCode.D },
                { "Attack", KeyCode.Mouse0 },
                { "Jump", KeyCode.Space },
                { "Use", KeyCode.E },
                { "Drop", KeyCode.G }


        };

    }
