using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int startGold;

    public int Gold { get; private set; }
    public event Action<int> OnGoldChange;

    private void Awake()
    {
        Gold = startGold;
    }

    public void AddGold(int amount)
    {
        if (amount <= 0) return;

        Gold += amount;

        OnGoldChange?.Invoke(Gold);
    }

    public bool SpendGold(int amount)
    {
        if (amount <= 0) return false;
        if (Gold < amount) return false;

        Gold -= amount;
        OnGoldChange?.Invoke(Gold);
        return true;
    }
}