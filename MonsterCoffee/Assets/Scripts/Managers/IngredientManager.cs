using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    public static IngredientManager Instance;

    private List<ScriptableIngredient> _ingredients;

    private void Awake()
    {
        Instance = this;
        _ingredients = Resources.LoadAll<ScriptableIngredient>("ingredients").ToList();
    }

    public BaseIngredient GetIngredientByType(IngredientType type)
    {
        return _ingredients.Where(u => u.Type == type).FirstOrDefault().IngredientPrefab;
    }
}
