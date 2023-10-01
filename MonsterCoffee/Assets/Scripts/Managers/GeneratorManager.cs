using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public static GeneratorManager Instance;

    [SerializeField] private CupGenerator _smallCupGen, _largeCupGen;
    [SerializeField] private List<BaseGenerator> _generators = new List<BaseGenerator>();

    private void Awake()
    {
        Instance = this;
    }

    public void EnableCupGenerators()
    {
        _smallCupGen.CanGenerate = true;
        _largeCupGen.CanGenerate = true;
    }

    public void DisableCupGenerators()
    {
        _smallCupGen.CanGenerate = false;
        _largeCupGen.CanGenerate = false;
    }
}
