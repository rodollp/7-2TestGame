using UnityEngine;

public class Work : MonoBehaviour
{
    public MonsterStatus MonsterStatus;


    public MonsterStatus FindWeakestTarget(Vector3 player,float attackRange, MonsterStatus[] monsters)
    {
        if(monsters.Length == 0)
        {
            return null;    
        }



        return FindWeakestTarget(player,attackRange, monsters);
    }
}
