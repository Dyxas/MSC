using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
    // Start is called before the first frame update
    public float oneRotateDeg = 45f;
    public float maxRotateDeg = 0;
    public int maxRotateVal = 0;
    public bool reverse;
    public bool x = false;
    public bool y = false;
    public bool z = false;
    public Vector3 defaultVector;

    private int currentRotateVal = 0;
    private Vector3 settedAxis;
    private Vector3 settedReverseAxis;
    private float settedEulerAxis;
    private bool isRotatingAlways = false;
    
    void Start()
    {
        if(maxRotateDeg == 0 && maxRotateVal == 0)
        {
            isRotatingAlways = true;
        }
        if(x)
        {
            float reverse = oneRotateDeg * -1;
            settedAxis = new Vector3(oneRotateDeg, 0, 0);
            settedReverseAxis = new Vector3(reverse, 0, 0);
        }
        if(y)
        {
            float reverse = oneRotateDeg * -1;
            settedAxis = new Vector3(0, oneRotateDeg, 0);
            settedReverseAxis = new Vector3(0, reverse, 0);
        }
        if(z)
        {
            float reverse = oneRotateDeg * -1;
            settedAxis = new Vector3(0, 0, oneRotateDeg);
            settedReverseAxis = new Vector3(0, 0, reverse);
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        if (x)
        {
            settedEulerAxis = transform.eulerAngles.x;
        }
        if (y)
        {
            settedEulerAxis = transform.eulerAngles.y;
        }
        if (z)
        {
            settedEulerAxis = transform.eulerAngles.z;
        }
        if(reverse)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (isRotatingAlways)
                {
                    transform.Rotate(settedAxis, Space.World);
                }
                else if (maxRotateDeg != 0)
                {
                    Debug.Log(settedEulerAxis);
                    if (settedEulerAxis > 1)
                        transform.Rotate(settedAxis, Space.World);
                }
                else if (maxRotateVal != 0 && maxRotateVal > currentRotateVal)
                {
                    if (Mathf.Round(settedEulerAxis) > oneRotateDeg)
                    {
                        transform.Rotate(settedAxis, Space.World);
                    }
                    else if (currentRotateVal < maxRotateVal)
                    {
                        currentRotateVal++;
                        transform.Rotate(settedAxis, Space.World);
                    }

                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (isRotatingAlways)
                {
                    transform.Rotate(settedReverseAxis, Space.World);
                }
                else if (maxRotateDeg != 0)
                {
                    Debug.Log(settedEulerAxis);
                    if (settedEulerAxis < maxRotateDeg || Mathf.Round(settedEulerAxis) == 0)
                    {
                        transform.Rotate(settedReverseAxis, Space.World);
                    }
                }
                else if (maxRotateVal != 0 && currentRotateVal >= 0)
                {

                    if (settedEulerAxis < 360 - oneRotateDeg)
                    {
                        transform.Rotate(settedReverseAxis, Space.World);
                    }
                    else if (currentRotateVal > 0)
                    {
                        transform.Rotate(settedReverseAxis, Space.World);
                        currentRotateVal--;
                    }

                }
            }
            return;
        }
        //Quaternion.Euler!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        if(Input.GetKeyUp(KeyCode.R))
        {
            transform.eulerAngles = defaultVector;
            currentRotateVal = 0;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (isRotatingAlways)
            {
                transform.Rotate(settedAxis, Space.World);
            }
            else if (maxRotateDeg != 0)
            {
                Debug.Log(settedEulerAxis);
                if (settedEulerAxis < maxRotateDeg)
                    transform.Rotate(settedAxis, Space.World);
            }
            else if (maxRotateVal != 0 && maxRotateVal > currentRotateVal)
            {
                Debug.Log(settedEulerAxis);
                Debug.Log(currentRotateVal);
                if (Mathf.Round(settedEulerAxis) < 360 - oneRotateDeg)
                {
                    transform.Rotate(settedAxis, Space.World);
                }
                else if(currentRotateVal < maxRotateVal)
                {
                    currentRotateVal++;
                    transform.Rotate(settedAxis, Space.World);
                }

            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel")  < 0)
        {
            if (isRotatingAlways)
            {
                transform.Rotate(settedReverseAxis, Space.World);
            }
            else if (maxRotateDeg != 0)
            {
                Debug.Log(settedEulerAxis);
                if (settedEulerAxis > 1)
                {
                    transform.Rotate(settedReverseAxis, Space.World);
                }
            }
            else if (maxRotateVal != 0 && currentRotateVal >= 0)
            {
                Debug.Log(settedEulerAxis);
                Debug.Log(currentRotateVal);
                if (settedEulerAxis > oneRotateDeg - 1)
                {
                    transform.Rotate(settedReverseAxis, Space.World);
                }
                else if(currentRotateVal > 0)
                {
                    transform.Rotate(settedReverseAxis, Space.World);
                    currentRotateVal--;
                }

            }
        }
    }

}
