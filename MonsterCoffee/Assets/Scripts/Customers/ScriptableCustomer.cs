using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Customer", menuName = "Scriptable Customer")]
public class ScriptableCustomer : ScriptableObject
{
    public CreatureTypes Type;
    public HeadModifier Head;
    public FaceModifier Face;
    public BaseCustomer CustomerPrefab;
}