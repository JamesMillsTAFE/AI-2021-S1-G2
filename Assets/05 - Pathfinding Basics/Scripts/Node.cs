using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody), typeof(MeshRenderer))]
public class Node : MonoBehaviour
{
    [SerializeField]
    private Color safe = Color.green;
    [SerializeField]
    private Color ignored = Color.red;

    private new Rigidbody rigidbody;
    private new BoxCollider collider;
    private new MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        collider = gameObject.GetComponent<BoxCollider>();
        collider.isTrigger = true;

        renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material.color = safe;
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider _other)
    {
        TryChangeColor(_other, ignored);
    }

    // OnTriggerStay is called once per frame for every Collider other that is touching the trigger
    private void OnTriggerStay(Collider _other)
    {
        TryChangeColor(_other, ignored);
    }

    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    private void OnTriggerExit(Collider _other)
    {
        TryChangeColor(_other, safe);
    }

    private void TryChangeColor(Collider _other, Color _color)
    {
        if(_other.GetComponent<Node>() || !_other.CompareTag("Pathfinding Obstacle"))
        {
            return;
        }

        if(renderer == null)
        {
            renderer = gameObject.GetComponent<MeshRenderer>();
        }

        renderer.material.color = _color;
    }
}
