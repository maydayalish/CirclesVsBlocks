using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
    public class ScreenToWorldRaycaster : MonoBehaviour
    {
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private UnityEvent<GameObject, Vector3> hitEvent;

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
}