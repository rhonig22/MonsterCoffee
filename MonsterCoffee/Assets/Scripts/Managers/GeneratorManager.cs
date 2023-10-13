using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public static GeneratorManager Instance;

    [SerializeField] private CupGenerator _smallCupGen, _largeCupGen;
    [SerializeField] private BaseGenerator _espressoMachine, _milkSteamer, _kettle, _chocolateGen, _teaGen, _iceGen;

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

    public void EnableDay(int day)
    {
        switch (day) {
            case 2:
                _teaGen.gameObject.SetActive(true);
                _kettle.gameObject.SetActive(true);
                break;
            case 3:
                _largeCupGen.gameObject.SetActive(true);
                _chocolateGen.gameObject.SetActive(true);
                _iceGen.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
