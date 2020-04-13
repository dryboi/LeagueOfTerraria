using Terraria.ModLoader;

namespace LeagueOfTerraria.Projectiles.Minions
{
    public abstract class Minion : ModProjectile
    {
        public override void AI()
        {
            CheckActive();
        }

        public abstract void CheckActive();
    }
}