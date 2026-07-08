using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int startGold;

    public int Gold { get; private set; }

    private void Awake()
    {
        Gold = startGold;
    }

    public void AddGold(int amount)
    {
        if (amount <= 0) return;

        Gold += amount;
        Debug.Log($"°ñµå È¹µæ : {amount}, ÇöÀç °ñµå : {Gold}");
    }

    public bool SpendGold(int amount)
    {
        if (amount <= 0) return false;
        if (Gold < amount) return false;

        Gold -= amount;
        Debug.Log($"°ñµå »ç¿ë : {amount}, ÇöÀç °ñµå : {Gold}");
        return true;
    }
}