namespace Assets.GameProject.Script.Interface
{
    public interface IWeaponAttack
    {
        void Attack(PlayerAttack playerAttack,WeaponStatus weapon,IDamageable target);
    }
}
