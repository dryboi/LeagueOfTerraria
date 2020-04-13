
using Terraria;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Buffs
{
	public class Zoomies : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("ZOOMIES!");
			Description.SetDefault("Boosts movement speed and attack speed");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			
            player.maxRunSpeed += 2.0f;
			player.moveSpeed += 1.6f;
            player.runAcceleration += 0.5f;
			player.meleeSpeed += 2.5f;
			
		}
	}
}