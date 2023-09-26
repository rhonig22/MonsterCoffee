using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGenerator : MonoBehaviour
{
    public IngredientType type;
    [SerializeField] private Transform _generateLocation;
    protected BaseIngredient _currentIngredient;

    protected void GenerateIngredient(int quantity)
    {
        if (_currentIngredient != null)
            return;

        var prefab = IngredientManager.Instance.GetIngredientByType(type);
        var newIngredient = Instantiate(prefab);
        newIngredient.transform.SetLocalPositionAndRotation(_generateLocation.position, Quaternion.identity);
        newIngredient.Quantity = quantity;
        newIngredient.SetGenerator(this);
        _currentIngredient = newIngredient;
    }

    public void RemoveCurrentIngredient()
    {
        _currentIngredient = null;
    }
}
