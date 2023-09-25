using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGenerator : MonoBehaviour
{
    public IngredientType type;
    [SerializeField] private Transform _generateLocation;

    protected void GenerateIngredient(int quantity)
    {
        var prefab = IngredientManager.Instance.GetIngredientByType(type);
        var newIngredient = Instantiate(prefab);
        newIngredient.transform.SetLocalPositionAndRotation(_generateLocation.position, Quaternion.identity);
        newIngredient.Quantity = quantity;
    }
}
