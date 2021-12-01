using UnityEngine;

public class BoltSystem : item
{

    public enum BoltType { Screw, Bolt }

    public bool IsFixedBolt;

    
    public BoltType _boltType;
    public float MaxDown;
    public float DefaultDown;

    public void Start()
    {
        DefaultDown = transform.position.y;
        MaxDown = transform.position.y - 0.053f;
    }

    private bool IsSameInstrumentType(InstrumentUse.instrument_Types instrument_Types)
    {
        if (instrument_Types == InstrumentUse.instrument_Types.Screwdive && _boltType == BoltType.Screw)
            return true;
        if (instrument_Types == InstrumentUse.instrument_Types.Wrench && _boltType == BoltType.Bolt)
            return true;

        return false;
    }

    public void Wrest()
    {
       if(IsFixedBolt)
        {
            transform.Translate(new Vector3(0, 0f, 0.08f));
            gameObject.AddComponent<Rigidbody>();
            // Добавить rb
        }

    }

    public void UnRoll(InstrumentUse.instrument_Types instrument_Types)
    {
        if (!IsSameInstrumentType(instrument_Types))
            return;

        if (transform.position.y >= DefaultDown) return;
        transform.Translate(new Vector3(0, 0f, 0.01f));
    }

    public void Roll(InstrumentUse.instrument_Types instrument_Types)
    {
        if (!IsSameInstrumentType(instrument_Types))
            return;

        if (transform.position.y <= MaxDown) return;
        transform.Translate(new Vector3(0, 0f, -0.01f));
    }
}
