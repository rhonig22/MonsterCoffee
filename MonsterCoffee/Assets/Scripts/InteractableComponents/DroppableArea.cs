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
        if (PlayerManager.Instance.CurrentlyDragging != null)
        {
            currentlyDragging = PlayerManager.Instance.CurrentlyDragging.GetComponent<DraggableObject>();
            currentlyDragging.Dropped.AddListener(OnDropped);
        }
    }

    private void OnMouseExit()
    {
        if (currentlyDragging != null)
        {
            currentlyDragging.Dropped.RemoveListener(OnDropped);
            currentlyDragging = null;
        }
    }

    private void OnDropped()
    {
        if (currentlyDragging != null)
        {
            droppedOn.Invoke(currentlyDragging.gameObject);
        }
    }
}
