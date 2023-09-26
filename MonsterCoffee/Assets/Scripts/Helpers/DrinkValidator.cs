using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DrinkValidator
{
    public static DrinkSuccess ValidateDrink(List<IngredientType> givenDrink, List<IngredientType> ingredients, List<IngredientType> dislikes)
    {
        foreach (IngredientType dislike in dislikes)
        {
            if (givenDrink.Contains(dislike))
                return DrinkSuccess.Wrong;
        }

        int matches = 0;
        var copyDrink = new List<IngredientType>(givenDrink);
        foreach (IngredientType ingredient in ingredients)
        {
            if (copyDrink.Contains(ingredient))
            {
                matches++;
                copyDrink.Remove(ingredient);
            }
        }

        if (matches <= 1)
            return DrinkSuccess.Wrong;
        else if (matches == ingredients.Count && matches == givenDrink.Count)
            return DrinkSuccess.Perfect;
        else
            return DrinkSuccess.Fine;
    }
}

public enum DrinkSuccess
{
    Wrong = 0,
    Fine = 1,
    Perfect = 2
}