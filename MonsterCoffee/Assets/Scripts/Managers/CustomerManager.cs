using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;
    [SerializeField] private List<Customer> _customerList = new List<Customer>();

    private List<ScriptableCustomer> _customers;
    private Customer _currentCustomer;

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
        switch (day)
        {
            case 1:
                Day1Customers();
                break;
            case 2:
                Day2Customers();
                break;
            case 3:
                Day3Customers();
                break;
            default:
                break;
        }
    }

    private void Day1Customers()
    {
        _customerList.Add(new Customer() { Creature = CreatureTypes.Skeleton, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
        _customerList.Add(new Customer() { Creature = CreatureTypes.Ghost, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
        _customerList.Add(new Customer() { Creature = CreatureTypes.Reaper, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
    }

    private void Day2Customers()
    {
        _customerList.Add(new Customer() { Creature = CreatureTypes.SeaCreature, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
        _customerList.Add(new Customer() { Creature = CreatureTypes.Cthulhu, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
        _customerList.Add(new Customer() { Creature = CreatureTypes.Reaper, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.Plain });
    }

    private void Day3Customers()
    {
        _customerList.Add(new Customer() { Creature = CreatureTypes.Skeleton, FaceModifier = FaceModifier.EyePatch, HeadModifier = HeadModifier.Plain });
        _customerList.Add(new Customer() { Creature = CreatureTypes.Ghost, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.PirateHat });
        _customerList.Add(new Customer() { Creature = CreatureTypes.Cthulhu, FaceModifier = FaceModifier.Plain, HeadModifier = HeadModifier.PirateHat });
    }

    public bool HasMoreCustomers()
    {
        return _customerList.Count > 0;
    }

    public void RedoCustomer()
    {
        _customerList.Add(_currentCustomer);
    }

    public void SpawnNextCustomer()
    {
        if (_customerList.Count == 0)
            return;

        _currentCustomer = _customerList[0];
        _customerList.RemoveAt(0);
        var prefab = GetCustomerPrefab(_currentCustomer);
        var customer = Instantiate(prefab);
        customer.transform.SetLocalPositionAndRotation(transform.position - Vector3.right * 12, transform.rotation);
        var lerper = customer.GetComponent<Lerper>();
        lerper.StartLerping(transform.position, 5);
        lerper.TargetReached.AddListener(customer.StartDrinkOrder);
        customer.StartWalking();
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