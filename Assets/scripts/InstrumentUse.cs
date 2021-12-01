using UnityEngine;

public class InstrumentUse : MonoBehaviour
{

    public enum instrument_Types { None,Screwdive, Hammer, Drill, Axe, Wrench, Pipe }

    public Transform handUser;

    public instrument_Types _Type;

    public string InstrumentName;
    public GameObject InstrumentPrefab;

    public void Set(instrument_Types inst_type)
    {
        _Type = inst_type;
        InstrumentPrefab = this.gameObject;
        if (this.gameObject.GetComponent<Rigidbody>() != null)
            Destroy(this.gameObject.GetComponent<Rigidbody>());
    }

}
