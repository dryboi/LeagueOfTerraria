using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LeagueOfTerraria.Projectiles.Bullets
{
	public class WhisperProjFour : ModProjectile
	{
        public override void SetStaticDefaults(){
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 2; 
            projectile.height = 2;  
            projectile.aiStyle = 1;      
            projectile.friendly = true;       
            projectile.hostile = false;     
            projectile.ranged = true;      
            projectile.penetrate = 1;   
            projectile.timeLeft = 460;
            projectile.alpha = 255;
            projectile.ignoreWater = true;   
            projectile.tileCollide = true;      
            projectile.extraUpdates = 3;  
            aiType = ProjectileID.Bullet;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
			width = 10;
			height = 10;
			return true;
		}

        public override void Kill(int timeLeft) {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 4.0f, 612, 100, 1f, projectile.owner, 0.0f, (float)projectile.whoAmI);
        }

       public override void AI() {
           if (++projectile.frameCounter >= 1) {
	         projectile.frameCounter = 0;
	        projectile.frame = ++projectile.frame % Main.projFrames[projectile.type];
            }   

           Lighting.AddLight(projectile.position, 0.0f, 0.1f, 0.3f);

           ++projectile.ai[0];
           if ((double)projectile.ai[0] >= 1) {
               Dust.NewDust(projectile.position, projectile.width, projectile.height, 188);
               projectile.ai[0] = -1;
           }
       }     

    }
}