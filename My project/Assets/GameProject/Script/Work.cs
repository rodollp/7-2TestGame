using UnityEngine;

public class Work : MonoBehaviour
{
    private float timer;
    private float cooldown;

    public Work(float cooldown)
    {
        this.cooldown = cooldown;
    }


    private void Update()
    {
        timer += Time.deltaTime;
    }
    private bool CanAttack()
    {
        if(cooldown > timer)
        {
            return false;
        }
        return true;
    }


    private void ResetTimer()
    {
        CanAttack();
        timer = 0f;

    }
}
