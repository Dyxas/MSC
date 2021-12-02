using UnityEngine;

public class Item : MonoBehaviour
{

    private Outline _outl { get; set; }

    public void Selected()
    {
        if (_outl != null) {
            return;
        }


        _outl = gameObject.AddComponent<Outline>();
        _outl.OutlineMode = Outline.Mode.OutlineAll;
        _outl.OutlineColor = Color.yellow;
        _outl.OutlineWidth = 5f;
    }

    public void UnSelected()
    {
        if (_outl != null) {
            Destroy(gameObject.GetComponent<Outline>());
        }
    }
}
