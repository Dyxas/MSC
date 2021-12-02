using UnityEngine;

public class Seatable : MonoBehaviour
{
    /*
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
        }*/

    /*if (Input.GetKey(KeyCode.G))
    {
        if (_instumentUse != null)
            DropActiveItem();
    }*/





    /*
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
    }*/
    void Start()
    {

    }

    void Update()
    {

    }
}
