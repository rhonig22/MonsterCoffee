using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;
    [SerializeField] private List<Customer> _customerList = new List<Customer>();

    private List<ScriptableCustomer> _customers;

    private void Awake()
    {
        Instance = this;
        _customers = Resources.LoadAll<ScriptableCustomer>("customers").ToList();
    }

    private void Start()
    {
    }

    public void SetUpCustomersForTheDay(int day)
    {
        _customerList.Clear();
        _customerList.Add(new Customer() { Creature = CreatureTypes.Skeleton, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
        _customerList.Add(new Customer() { Creature = CreatureTypes.Ghost, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
        _customerList.Add(new Customer() { Creature = CreatureTypes.Reaper, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
        _customerList.Add(new Customer() { Creature = CreatureTypes.SeaCreature, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
        _customerList.Add(new Customer() { Creature = CreatureTypes.Cthulhu, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
    }

    public bool HasMoreCustomers()
    {
        return _customerList.Count > 0;
    }

    public void SpawnNextCustomer()
    {
        if (_customerList.Count == 0)
            return;

        var nextCustomer = _customerList[0];
        _customerList.RemoveAt(0);
        var prefab = GetCustomerPrefab(nextCustomer);
        var customer = Instantiate(prefab);
        customer.transform.SetLocalPositionAndRotation(transform.position, transform.rotation);
    }

    private BaseCustomer GetCustomerPrefab(Customer customer)
    {
        return _customers.Where(u => u.Type == customer.Creature).Where(u => u.Head == customer.HeadModifier).Where(u => u.Face == customer.FaceModifier).FirstOrDefault().CustomerPrefab;
    }
}

public class Customer
{
    public CreatureTypes Creature { get; set; }
    public HeadModifier HeadModifier { get; set; }
    public FaceModifier FaceModifier { get; set; }
}