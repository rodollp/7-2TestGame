

namespace Assets.GameProject.Script.Weapon
{
    public class WeaponTimer
    {
        private float elapsedTime;

        public void UpdateTimer(float deltaTime)
        {
            elapsedTime += deltaTime;
        }

        public bool CanAttack(float cooldown)
        {
            return elapsedTime >= cooldown;
        }

        public void Reset()
        {
            elapsedTime = 0f;
        }
    }
}
