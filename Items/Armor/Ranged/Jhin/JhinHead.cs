using Terraria;
using Terraria.ModLoader;


namespace LeagueOfTerraria.Items.Armor.Ranged.Jhin
{
	[AutoloadEquip(EquipType.Head)]
	public class JhinHead : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Virtuosic Mask");
			Tooltip.SetDefault("\"In carnage, I bloom, like a flower in the dawn.\"");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1;
			item.rare = 2;
			item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("JhinBody") && legs.type == mod.ItemType("JhinLegs");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "";
			
		}

		public override void AddRecipes() {
			
		}
	}
}