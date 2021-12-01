using UnityEngine;

public class item : MonoBehaviour
{
    public GameObject PickedPlayer;
    public bool isPickupItem;
    Outline outl;

    public InstrumentUse.instrument_Types instrument_Type;
    public bool IsInstrument;
    public void IsSelected()
    {
        if (outl != null) return;
        outl = gameObject.AddComponent<Outline>();
        outl.OutlineMode = Outline.Mode.OutlineAll;
        outl.OutlineColor = Color.yellow;
        outl.OutlineWidth = 5f;
    }

    public InstrumentUse getInstrument()
    {
        var obj = Instantiate(Resources.Load("Prefabs/" + gameObject.name, typeof(GameObject))) as GameObject;
        obj.AddComponent<InstrumentUse>();
        obj.GetComponent<InstrumentUse>().Set(instrument_Type);
        obj.gameObject.transform.localScale = gameObject.transform.localScale;

        if (gameObject.GetComponent<MeshCollider>() != null)
        {
            obj.AddComponent<MeshCollider>().convex = true;
            obj.GetComponent<MeshCollider>().sharedMesh = gameObject.GetComponent<MeshCollider>().sharedMesh;
        } else
        {
            obj.AddComponent<BoxCollider>().size = gameObject.GetComponent<BoxCollider>().size;
        }
       
        return obj.GetComponent<InstrumentUse>();
    }

    public void UnSelected()
    {
        if (outl != null)
            Destroy(gameObject.GetComponent<Outline>());
    }

    public bool CanPickup()
    {
        if (isPickupItem)
            return true;

        return false;
    }

    public void Pickup()
    {
        if (!CanPickup()) return;
        Destroy(gameObject);

    }
}
