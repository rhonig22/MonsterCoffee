using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public int Capacity = 3;
    public List<IngredientType> Ingredients;
    [SerializeField] private SpriteRenderer _top;
    [SerializeField] private SpriteRenderer _mid;
    [SerializeField] private SpriteRenderer _bottom;
    [SerializeField] private AudioSource _audioSource;

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
            _audioSource.Play();
            Ingredients.Add(ingredient.IngredientType);
            switch (Ingredients.Count)
            {
                case 1:
                    _bottom.color = ingredient.SpriteColor;
                    break;
                case 2:
                    _mid.color = ingredient.SpriteColor;
                    break;
                case 3:
                    _top.color = ingredient.SpriteColor;
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
