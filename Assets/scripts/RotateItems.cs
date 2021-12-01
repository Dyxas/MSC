using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
    // Start is called before the first frame update
    public int oneRotate = 90;
    public int maxRotate = 0;

    public float defaultPos;
    private bool isRotatingAlways = false;
    
    void Start()
    {
        if(maxRotate == 0)
        {
            isRotatingAlways = true;
        }

        if (maxRotate < oneRotate && !isRotatingAlways)
        {
            Debug.LogError("Max rotate is lower than one rotate");
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
        defaultPos = transform.position.y;
    }

    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(isRotatingAlways)
            {
                var vector = transform.rotation;
                if(vector.y < 360)
                    transform.Rotate(0, 0, 5f);
                else
                    transform.rotation.Set(0, 0, 0, 0);

            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (isRotatingAlways)
            {
                var vector = transform.rotation;
                if (vector.y < 360)
                    transform.Rotate(0, 0, -5f);
                else
                    transform.rotation.Set(0, 0, 0, 0);

            }
        }
    }

}
