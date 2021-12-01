using UnityEngine;

public class Tree : MonoBehaviour
{

    private bool IsBroken;
    private int MaxAttack { get; set; }
    private int GatherStat { get; set; }

    private float RemoveTime;

    void FixedUpdate()
    {
        if (IsBroken)
        {
            if (RemoveTime <= Time.time)
                Destroy(gameObject);
        }
    }

    public void Attack()
    {
        if (IsBroken) return;
        if (GatherStat >= MaxAttack) {
            DropTree();
            DropResources();
        }


        GatherStat++;
    }

    private void RemoveEnt()
    {
        RemoveTime = Time.time + 10f;
        IsBroken = true;
    }

    private void DropResources()
    {
        int woodDrop = MaxAttack / 5;
        for (int i = 0; i < woodDrop; i++)
        {
            var plank = (Instantiate(Resources.Load("Prefabs/wood_planks"), new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), new Quaternion()) as GameObject);
            plank.layer = 9;
            plank.AddComponent<Rigidbody>();
            plank.AddComponent<MeshCollider>().convex = true;
        }
    }

    private void DropTree()
    {
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.AddComponent<Rigidbody>().mass = 0.1f;
        RemoveEnt();
    }

    void Start()
    {
        Physics.IgnoreLayerCollision(8, 9);
        MaxAttack = UnityEngine.Random.Range(5, 20);
    }
    
}
