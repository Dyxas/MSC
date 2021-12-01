using UnityEngine;
using UnityEngine.UI;

public class playerControll : MonoBehaviour
{

    public Transform handR;
    public Transform LTigh, LCalf, RThigh, RCalf;

    private bool IsSeat;
    private float LastAttackTime;

    [SerializeField] private Animator m_animator = null;

    private InstrumentUse _instumentUse;
    private item activeItem;

    public void GetInstrument()
    {

        Vector3 scale = (_instumentUse.InstrumentPrefab as GameObject).transform.localScale;
        (_instumentUse.InstrumentPrefab as GameObject).transform.SetParent(handR);
        (_instumentUse.InstrumentPrefab as GameObject).transform.localRotation = new Quaternion(0, 0, 180, 0);
        (_instumentUse.InstrumentPrefab as GameObject).transform.localPosition = new Vector3(-0.0091f, 0.0023f, -0.0007f);
    }

    public bool IsSeating()
    {
        return IsSeat;
    }

    void Start()
    {
        //RenderSettings.ambientLight = Color.black;
        //RenderSettings.ambientIntensity = -0.2f;
    }

    void FixedUpdate()
    {

    }

    private void DropActiveItem()
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
    }

    void Update()
    {


        if (IsSeat)
        {
            if (Input.GetKey(KeyCode.E))
            {
                m_animator.enabled = true;
                IsSeat = false;
                GetComponent<Rigidbody>().detectCollisions = true;
                GetComponent<Rigidbody>().isKinematic = false;
                transform.SetPositionAndRotation(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), new Quaternion());
            }
            return;
        }

        if (Input.GetKey(KeyCode.G))
        {
            if (_instumentUse != null)
                DropActiveItem();
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-0.01f, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0.01f, 0, 0));
        }
        var c = Camera.main.transform;

        RaycastHit raycast = new RaycastHit();
        Physics.Raycast(c.position, c.TransformDirection(Vector3.forward),out raycast, 100f);


        if (Input.GetMouseButtonUp(0))
        {
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
        }

        if (raycast.collider != null)
        {
            if (raycast.collider.gameObject.layer == 10)
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    m_animator.enabled = false;
                    GetComponent<Rigidbody>().detectCollisions = false;
                    GetComponent<Rigidbody>().isKinematic = true;
                    Vector3 pos = raycast.collider.transform.position;
                    transform.SetPositionAndRotation(new Vector3(pos.x, pos.y + 0.3f, pos.z), new Quaternion());
                    LTigh.eulerAngles = new Vector3(0, 90, 0);
                    RThigh.eulerAngles = new Vector3(0, 90, 0);
                    RCalf.eulerAngles = new Vector3(0, 85, 0);
                    LCalf.eulerAngles = new Vector3(0, 85, 0);

                    IsSeat = true;
                }
            }
        }

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
       

        
        gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * 1, 0);

     
        if (c.localEulerAngles.y <= 353 && -Input.GetAxis("Mouse Y") < 0) return;
        if (c.localEulerAngles.y >= 359.7 && -Input.GetAxis("Mouse Y") > 0) return;
  
        
        c.Rotate(-Input.GetAxis("Mouse Y") * 1, 0, 0);
    }
}
