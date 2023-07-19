using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
    public class Clickable : MonoBehaviour
    {
        [SerializeField] private UnityEvent clickEvent;

        private void OnMouseDown()
        {
            clickEvent.Invoke();
        }
    }
}

