using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
    // Start is called before the first frame update
    public float oneRotateDeg = 30f;
    public float maxRotateDeg = 0;
    public int maxRotateVal = 0;

    private int steps;
    private int currentStep = 0;
    private int currentRotateVal = 0;
    private bool isRotatingAlways = false;
    
    void Start()
    {
        if(maxRotateDeg == 0 && maxRotateVal == 0)
        {
            isRotatingAlways = true;
        }

        if (maxRotateDeg < oneRotateDeg && !isRotatingAlways)
        {
            Debug.LogError("Max rotate is lower than one rotate");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        steps = 360 / (int)oneRotateDeg;
    }

    

    // Update is called once per frame
    void Update()
    {

        //Quaternion.Euler!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        var mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw > 0)
        {
            Debug.Log(isRotatingAlways);
            if (isRotatingAlways)
            {
                transform.Rotate(0, oneRotateDeg, 0, Space.World);
                Debug.Log(transform.rotation.z);
            }
            else if (maxRotateDeg != 0)
            {
                
                if (maxRotateDeg < 180)
                    if (transform.rotation.z < maxRotateDeg)
                        transform.Rotate(0, 0, oneRotateDeg, Space.World);
                    else { }

                    if (transform.rotation.z < (maxRotateDeg % 180 - 180))
                        transform.Rotate(0, 0, oneRotateDeg, Space.World);
            }
            else if (maxRotateVal != 0 && maxRotateVal > currentRotateVal)
            {
                
                if(currentStep < steps)
                {
                    currentStep++;
                    transform.Rotate(0, 0, oneRotateDeg);
                }
                else
                {
                    currentRotateVal++;
                    currentStep = 0;
                }
            }
        }
        else if(mw < 0)
        {
            if (isRotatingAlways)
            {
                transform.Rotate(0, 0, (0 - oneRotateDeg), Space.World);
            }
            else if (maxRotateDeg != 0 || maxRotateVal != 0)
            {
                if (transform.rotation.z > 0)
                {

                }
            }
        }
    }

}
