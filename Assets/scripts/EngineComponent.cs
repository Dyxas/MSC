using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EngineComponent : MonoBehaviour
{
    List<EnginePart> connectedParts = new List<EnginePart>();

    struct Engine
    {

        public EnginePart Piston1;
        public EnginePart Piston2;
        public EnginePart Piston3;
        public EnginePart Piston4;

        public bool AllEnginePartsCorrect()
        {
            
            int enginePartsCount = this.GetType().GetFields().Length;
            int correctEngineParts = 0;

            foreach(var enginePart in GetType().GetFields())
            {
                if (enginePart.GetValue(this) == null) continue;
                correctEngineParts++;
            }

            if (correctEngineParts == enginePartsCount) return true;
            return false;
        }
    }

    void Start()
    {
        Engine eng = new Engine();
        eng.Piston1 = new EnginePart();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
