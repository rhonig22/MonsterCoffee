using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cupPrefab;
    [SerializeField] private Transform _generateLocation;
    public bool CanGenerate = true;

    protected void GenerateCup()
    {
        if (!CanGenerate)
            return;

        var newCup = Instantiate(_cupPrefab);
        newCup.transform.SetLocalPositionAndRotation(_generateLocation.position, Quaternion.identity);
        GameManager.Instance.NextGameState();
    }

    private void OnMouseDown()
    {
        GenerateCup();
    }
}
