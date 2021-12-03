using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveHeating : MonoBehaviour
{
    public GameObject lightData;
    public bool x = false;
    public bool y = false;
    public bool z = false;

    private float settedEulerAxis;
    private float settedDefaultEulerAxis;
    // Start is called before the first frame update
    void Start()
    {
        if (x)
        {
            settedDefaultEulerAxis = transform.eulerAngles.x;
        }
        if (y)
        {
            settedDefaultEulerAxis = transform.eulerAngles.y;
        }
        if (z)
        {
            settedDefaultEulerAxis = transform.eulerAngles.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(settedEulerAxis);
        Debug.Log(settedDefaultEulerAxis);
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
        if (Mathf.Round(settedEulerAxis) != Mathf.Round(settedDefaultEulerAxis))
        {
            lightData.SetActive(true);
        }
        else
        {
            lightData.SetActive(false);
        }
    }
}
