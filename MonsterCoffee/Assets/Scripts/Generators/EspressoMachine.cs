using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspressoMachine : BaseGenerator
{
    [SerializeField] private AudioSource _audioSource;

    private void OnMouseUp()
    {
        GenerateIngredient(1);
        _audioSource.Play();
    }
}
