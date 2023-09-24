using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DroppableArea : MonoBehaviour
{
    private DraggableObject currentlyDragging = null;
    public UnityEvent<GameObject> droppedOn = new UnityEvent<GameObject>();
    private void OnMouseEnter()
    {
        currentlyDragging = PlayerManager.Instance.CurrentlyDragging.GetComponent<DraggableObject>();
        currentlyDragging.Dropped.AddListener(OnDropped);
    }

    private void OnMouseExit()
    {
        currentlyDragging.Dropped.RemoveListener(OnDropped);
        currentlyDragging = null;
    }

    private void OnDropped()
    {
        if (currentlyDragging != null)
        {
            droppedOn.Invoke(currentlyDragging.gameObject);
        }
    }
}
