using System;
using UnityEngine;
using UnityEngine.UI;

public class playerControll : MonoBehaviour
{




    [SerializeField] public float walkScale = 10;
    [SerializeField] public float mouseMoveSpeedScale = 15;


    private Item _seeItem { get; set; }

    private readonly float _smoothMoveScale = 10;
    private readonly float _distanceVisualItem = 100f;
    private Transform _cameraTransform { get; set; }
    /*public void GetInstrument()
    {

        Vector3 scale = (_instumentUse.InstrumentPrefab as GameObject).transform.localScale;
        (_instumentUse.InstrumentPrefab as GameObject).transform.SetParent(handR);
        (_instumentUse.InstrumentPrefab as GameObject).transform.localRotation = new Quaternion(0, 0, 180, 0);
        (_instumentUse.InstrumentPrefab as GameObject).transform.localPosition = new Vector3(-0.0091f, 0.0023f, -0.0007f);
    }

    /*public bool IsSeating()
    {
        return IsSeat;
    }*/

    void Start()
    {
        _cameraTransform = Camera.main.transform;
    }

    /* private void DropActiveItem()
     {
         if (_instumentUse == null) return;
         _instumentUse.gameObject.transform.parent = null;
         _instumentUse.transform.position = transform.position + new Vector3(0.5f, 0, 0);
         _instumentUse.gameObject.AddComponent<Rigidbody>();
         var instrumentTemp = _instumentUse.gameObject.GetComponent<InstrumentUse>();
         var item =_instumentUse.gameObject.AddComponent<item>();
         item.gameObject.name = item.gameObject.name.Replace("(Clone)", "");
         item.isPickupItem = true;
         item.IsInstrument = instrumentTemp._Type != InstrumentUse.instrument_Types.None;
         item.instrument_Type = instrumentTemp._Type;

         Destroy(instrumentTemp);

         m_animator.SetTrigger("Pickup");
         _instumentUse = null;
     }*/


    private void MouseControll()
    {
        float axisX = Input.GetAxis("Mouse X") * mouseMoveSpeedScale * Time.timeScale;
        float axisY = Input.GetAxis("Mouse Y") * mouseMoveSpeedScale * Time.timeScale;
        gameObject.transform.Rotate(0, axisX, 0);

        if (_cameraTransform.eulerAngles.x + Math.Abs(axisY) >= 52 && _cameraTransform.eulerAngles.x + Math.Abs(axisY) < 80 && axisY < 0) return;
        if (_cameraTransform.eulerAngles.x - Math.Abs(axisY) <= 311 && _cameraTransform.eulerAngles.x - Math.Abs(axisY) >= 80 && axisY > 0) return;
        _cameraTransform.eulerAngles += new Vector3(-axisY, 0, 0);

    }

    private void WASDControll()
    {
        Vector3 transformPosition = Vector3.zero;

        if (Input.GetKey(Utilities.Controlls["Left"])) {
            transformPosition = Vector3.left;
        } else if (Input.GetKey(Utilities.Controlls["Right"])) {
            transformPosition = Vector3.right;
        }

        if (transformPosition.Equals(Vector3.zero)) return;
        transform.Translate(transformPosition / _smoothMoveScale * Time.deltaTime * walkScale);
    }

    /*
      if (_instumentUse != null && _instumentUse._Type == InstrumentUse.instrument_Types.Axe)
            {
                
                if (raycast.collider.GetComponent<Tree>() != null)
                {
                    if (LastAttackTime < Time.time)
                    {
                        raycast.collider.GetComponent<Tree>().Attack();
                        LastAttackTime = Time.time + 0.5f;
                    }
                }
            }

    */

    private void AttackControll()
    {
        if (!Input.GetKey(Utilities.Controlls["Attack"]))
            return;

    }

    private void CheckSeeItem()
    {
        Item item;
        if (!GetSeeItem(out item)) {
            if (_seeItem != null) {
                _seeItem.UnSelected();
                _seeItem = null;
            }
            return;
        } else {
            if (_seeItem == item) {
                return;
            } else {
                if (_seeItem != null) {
                    _seeItem.UnSelected();
                }
            }
        }

        
        
        _seeItem = item;
        _seeItem.Selected();
    }

    private bool GetSeeItem(out Item item)
    {
        RaycastHit raycast = new RaycastHit();
        Physics.Raycast(_cameraTransform.position, _cameraTransform.TransformDirection(Vector3.forward), out raycast, _distanceVisualItem);

        if (raycast.collider == null || raycast.collider.GetComponent<Item>() == null) {
            item = null;
            return false;
        }

        item = raycast.collider.GetComponent<Item>();
        return true;
    }


    void Update()
    {
        WASDControll();
        MouseControll();
        AttackControll();
        CheckSeeItem();
        /*

        
        float mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw != 0)
        {

            if (raycast.collider.GetComponent<BoltSystem>() != null)
            {
                if (_instumentUse != null)
                {
                    if(_instumentUse._Type == InstrumentUse.instrument_Types.Pipe)
                    {
                        raycast.collider.GetComponent<BoltSystem>().Wrest(); 
                    }
                    else
                    {
                        if (mw < 0)
                            raycast.collider.GetComponent<BoltSystem>().UnRoll(_instumentUse._Type);
                        else
                            raycast.collider.GetComponent<BoltSystem>().Roll(_instumentUse._Type);
                    }

                }
            }
        }

        if (raycast.collider != null)
        {
            if (raycast.collider.GetComponent("item") != null)
            {
                
                if (activeItem != raycast.collider.GetComponent<item>())
                {
                    activeItem?.UnSelected();
                }

                activeItem = raycast.collider.GetComponent<item>();
                activeItem.IsSelected();
                if (Input.GetKeyUp(KeyCode.E))
                {

                    if (activeItem.IsInstrument)
                    {
                        if (_instumentUse != null)
                            DropActiveItem();
                        _instumentUse = activeItem.getInstrument();
                        GetInstrument();
                        
                        (raycast.collider.GetComponent("item") as item).Pickup();
                        m_animator.SetTrigger("Pickup");
                    }         

                }
            }
            else
            {
                if (activeItem != null)
                {
                    activeItem.UnSelected();
                    activeItem = null;
                }
            }
        }
       

       
        */
    }
}
