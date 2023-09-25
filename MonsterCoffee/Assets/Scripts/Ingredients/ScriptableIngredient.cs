using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Scriptable Ingredient")]
public class ScriptableIngredient : ScriptableObject
{
    public IngredientType Type;
    public BaseIngredient IngredientPrefab;
}