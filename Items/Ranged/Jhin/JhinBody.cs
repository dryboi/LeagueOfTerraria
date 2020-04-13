using Terraria;
using Terraria.ModLoader;


namespace LeagueOfTerraria.Items.Armor.Ranged.Jhin
{
	[AutoloadEquip(EquipType.Body)]
	public class JhinBody : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Virtuosic Garb");
			Tooltip.SetDefault("\"My audience awaits.\"");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1;
			item.rare = 2;
			item.defense = 5;
		}


		public override void AddRecipes() {
			
		}
	}
}