using UnityEngine;
using UnityEngine.Events;

public class ScreenToWorldRaycaster : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject, Vector3> hitEvent;
    [SerializeField] private LayerMask targetLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
            {
                GameObject hitObject = hit.collider.gameObject;
                hitEvent?.Invoke(hitObject, hit.point);
            }
        }
    }
}