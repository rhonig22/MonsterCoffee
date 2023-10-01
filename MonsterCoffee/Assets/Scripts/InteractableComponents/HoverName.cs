using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverName : MonoBehaviour
{
    [SerializeField] private string _name;

    private void OnMouseEnter()
    {
        UXManager.Instance.ToggleItemInfo(true, _name);
    }

    private void OnMouseExit()
    {
        UXManager.Instance.ToggleItemInfo(false, "");
    }
}
