using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public int Capacity = 3;
    public List<IngredientType> Ingredients;
    [SerializeField] private SpriteRenderer top;
    [SerializeField] private SpriteRenderer mid;
    [SerializeField] private SpriteRenderer bottom;

    public void RecieveIngredient(GameObject dropped)
    {
        var ingredient = dropped.GetComponent<BaseIngredient>();
        if (ingredient != null)
        {
            AddIngredient(ingredient);
        }
    }

    public void AddIngredient(BaseIngredient ingredient)
    {
        if (Ingredients.Count < Capacity)
        {
            Ingredients.Add(ingredient.IngredientType);
            switch (Ingredients.Count)
            {
                case 1:
                    bottom.color = ingredient.SpriteColor;
                    break;
                case 2:
                    mid.color = ingredient.SpriteColor;
                    break;
                case 3:
                    top.color = ingredient.SpriteColor;
                    break;
                default:
                    break;
            }

            Destroy(ingredient.gameObject);
        }

        if (Ingredients.Count == Capacity)
        {
            GetComponent<DraggableObject>().enabled = true;
            GetComponent<DroppableArea>().enabled = false;
        }
    }
}
