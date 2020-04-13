
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace LeagueOfTerraria.Projectiles.Magic
{
	
	public class ProwlingProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void AI() {
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64);
			Main.dust[dust].velocity /= 2f;
			
			if (projectile.localAI[0] == 0f) {
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 500f;
			bool target = false;
			for (int k = 0; k < 200; k++) {
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5) {
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance) {
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target) {
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
				AdjustMagnitude(ref projectile.velocity);
			}
			
		}

		private void AdjustMagnitude(ref Vector2 vector) {
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 4f) {
				vector *= 4f / magnitude;
			}
		}

	}
}