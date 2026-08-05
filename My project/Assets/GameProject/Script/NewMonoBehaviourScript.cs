using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private int currentHp = 100;

    public void Heal(int amount)
    {
        currentHp += amount;

        if(currentHp >= 100)
        {
            currentHp  = 100;   
        }
    }
}
