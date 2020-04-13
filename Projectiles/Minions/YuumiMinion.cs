using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Projectiles.Minions
{
	public class YuumiMinion : ModProjectile
	{
		public override void SetStaticDefaults()
         {
			Main.projFrames[projectile.type] = 6;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

		public override void SetDefaults()
         {
			projectile.netImportant = true;
			projectile.height = 32;
			projectile.width = 38;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 0;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void AI()
        {
            Player player = Main.player[projectile.owner];
			projectile.frameCounter++;
            if (projectile.frameCounter >= 6) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= (int)Main.projFrames[projectile.type]) projectile.frame = 0;
            float speed = 4.0f;
            Vector2 position = new Vector2((float)(player.direction * 30), -20f); position.Y += (float)Math.Cos((double)projectile.ai[0] * 0.05) * 4.0f;
            Vector2 dustPos = new Vector2(projectile.spriteDirection == -1 ? -6.0f : -3.0f, -20.0f).RotatedBy((double)projectile.rotation, new Vector2());
            
            projectile.rotation = projectile.velocity.X * 0.095f;
            projectile.spriteDirection = projectile.direction;
            
            position.X += (float)(-player.direction * 64);
            projectile.direction = projectile.spriteDirection = player.direction;
                Vector2 distancePosition = player.MountedCenter + position;
                float maxDistance = Vector2.Distance(projectile.Center, distancePosition);
            if ((double)maxDistance > 1000.0) projectile.Center = player.Center + position;
                Vector2 zeroPoint = distancePosition - projectile.Center;
            if ((double)maxDistance < (double)speed)
            {
                    Vector2 speedTo = projectile.velocity * 0.25f;
                    projectile.velocity = speedTo;
            }
             if (zeroPoint != Vector2.Zero)
            {
                    if ((double)zeroPoint.Length() < (double)speed * 0.5) projectile.velocity = zeroPoint;
                    else projectile.velocity = zeroPoint * 0.1f;
            }
            
            ++projectile.ai[0]; ++projectile.ai[1];
            if ((double)projectile.ai[0] >= 0.0) 
            {                
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.NextFloat(-8f, 8f), 4.0f, mod.ProjectileType("ProwlingProjectile"), 50, 1f, projectile.owner, 0.0f, (float)projectile.whoAmI);
                projectile.ai[0] = -450.0f;
            }
            if ((double)projectile.ai[1] >= 0.0) 
            {   
                for(int f = 0; f < 40; f++)
                {
                    Dust.NewDust(player.position, player.width, projectile.height, 74);
                }         

                player.statLife += 20;
                player.HealEffect(20);
                player.AddBuff(mod.BuffType("Zoomies"), 200);
                projectile.ai[1] = -600.0f;
            }
            projectile.netUpdate = true;

            if (player.dead)
                player.GetModPlayer<LOTPlayer>().yuumi = false;
            if (!player.GetModPlayer<LOTPlayer>().yuumi)
                return;
            projectile.timeLeft = 2;
        }
        
	}
}