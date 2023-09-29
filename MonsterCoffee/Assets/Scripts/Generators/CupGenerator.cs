using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cupPrefab;
    [SerializeField] private Transform _generateLocation;

    protected void GenerateCup()
    {
        var newCup = Instantiate(_cupPrefab);
        newCup.transform.SetLocalPositionAndRotation(_generateLocation.position, Quaternion.identity);
    }

    private void OnMouseDown()
    {
        GenerateCup();
    }
}
