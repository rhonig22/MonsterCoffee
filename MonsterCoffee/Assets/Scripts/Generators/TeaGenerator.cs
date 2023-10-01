using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaGenerator : BaseGenerator
{
    // Update is called once per frame
    void Update()
    {
        if (_currentIngredient == null)
            GenerateIngredient(1);
    }
}
