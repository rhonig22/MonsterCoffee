using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DrinkConverter
{
    public static List<IngredientType> GetIngredientList(DrinkNames drinkName)
    {
        switch (drinkName)
        {
            case DrinkNames.Doppio:
                return new List<IngredientType>() { IngredientType.Espresso, IngredientType.Espresso };
            case DrinkNames.Cappuccino:
                return new List<IngredientType>() { IngredientType.Espresso, IngredientType.SteamedMilk };
            case DrinkNames.WarmMilk:
                return new List<IngredientType>() { IngredientType.SteamedMilk, IngredientType.SteamedMilk };
            case DrinkNames.Tea:
                return new List<IngredientType>() { IngredientType.Teabag, IngredientType.HotWater };
            case DrinkNames.ChaiLatte:
                return new List<IngredientType>() { IngredientType.Teabag, IngredientType.SteamedMilk };
            case DrinkNames.HotWater:
                return new List<IngredientType>() { IngredientType.HotWater, IngredientType.HotWater };
            case DrinkNames.Mocha:
                return new List<IngredientType>() { IngredientType.Espresso, IngredientType.SteamedMilk, IngredientType.Chocolate };                                       
            case DrinkNames.IcedCoffee:
                return new List<IngredientType>() { IngredientType.Espresso, IngredientType.Espresso, IngredientType.Ice };
            case DrinkNames.IcedLatte:
                return new List<IngredientType>() { IngredientType.Espresso, IngredientType.SteamedMilk, IngredientType.Ice };
            case DrinkNames.HotChocolate:
                return new List<IngredientType>() { IngredientType.SteamedMilk, IngredientType.SteamedMilk, IngredientType.Chocolate };
            case DrinkNames.LondonFog:
                return new List<IngredientType>() { IngredientType.Teabag, IngredientType.HotWater, IngredientType.SteamedMilk };
            case DrinkNames.Frappe:
                return new List<IngredientType>() { IngredientType.Espresso, IngredientType.Chocolate, IngredientType.Ice };
            case DrinkNames.MilkShake:
                return new List<IngredientType>() { IngredientType.SteamedMilk, IngredientType.Chocolate, IngredientType.Ice };
            case DrinkNames.DirtyChai:
                return new List<IngredientType>() { IngredientType.Teabag, IngredientType.SteamedMilk, IngredientType.Espresso };
            case DrinkNames.ChocolateMintTea:
                return new List<IngredientType>() { IngredientType.Teabag, IngredientType.HotWater, IngredientType.Chocolate };
            case DrinkNames.ChocolateChai:
                return new List<IngredientType>() { IngredientType.Teabag, IngredientType.SteamedMilk, IngredientType.Chocolate };
            case DrinkNames.IcedTea:
                return new List<IngredientType>() { IngredientType.Teabag, IngredientType.HotWater, IngredientType.Ice };
            default:
                return null;
        }
    }
}

public enum DrinkNames
{
    Doppio = 0,
    Cappuccino = 1,
    WarmMilk = 2,
    Tea = 3,
    Mocha = 4,
    IcedCoffee = 5,
    IcedLatte = 6,
    HotChocolate = 7,
    LondonFog = 8,
    HotWater = 9,
    Frappe = 10,
    ChaiLatte = 11,
    DirtyChai = 12,
    MilkShake = 13,
    ChocolateMintTea = 14,
    ChocolateChai = 15,
    IcedTea = 16,
}