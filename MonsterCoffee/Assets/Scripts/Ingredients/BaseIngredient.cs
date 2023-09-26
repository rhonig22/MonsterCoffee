using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIngredient : MonoBehaviour
{
    public IngredientType IngredientType;
    public int Quantity = 1;
    public Color SpriteColor = Color.white;
    private BaseGenerator _generator;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = SpriteColor;
    }

    public void SetGenerator(BaseGenerator generator)
    {
        if (_generator == null)
            _generator = generator;
    }

    private void OnDestroy()
    {
        _generator.RemoveCurrentIngredient();
    }
}

public enum IngredientType
{
    Espresso = 0,
    Milk = 1,
    SteamedMilk = 2,
    Cream = 3,
    Sugar = 4,
    Chocolate = 5
}