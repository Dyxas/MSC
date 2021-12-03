using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveHeating : MonoBehaviour
{
    public GameObject KnobData;
    public Material heat;
    public Material standart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Round(KnobData.transform.eulerAngles.z) != 180)
        {
            gameObject.GetComponent<MeshRenderer>().material = heat;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = standart;
        }
    }
}
