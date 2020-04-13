using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace LeagueOfTerraria.NPCs.Town
{
    [AutoloadHead]
    public class Yuumi : ModNPC
    {
        public override string Texture => "LeagueOfTerraria/NPCs/Town/Yuumi";
        public override bool Autoload(ref string name)
        {
            name = "MagicalCat";
            return mod.Properties.Autoload;
        }
        public override void SetDefaults() {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 15;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
            NPCID.Sets.HatOffsetY[npc.type] = -8;
        }
        
        public override void SetStaticDefaults() {
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;

        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			if(NPC.downedBoss1) {
                return true;
            }
            return false;
		}

        public override string TownNPCName() {
			return "Yuumi";
		}
		 
         public override string GetChat() {			
			switch (Main.rand.Next(4)) {
				case 0:
					return "Where's my fishy fishy fish for my dishy dishy dish?";
				case 1:
					return "Tell me the game plan again. Wait. Fish! Someone has fish! Where is it?";
				case 2:
					{
					return "Cats make great companions! Just ask my master... who disappeared under mysterious circumstances.";
					}
				default:
					return "You and me, we got this!";
			}
		}

        public override void SetChatButtons(ref string button, ref string button2)  {
			button = "You and Me!";
		}

        public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
            Player player = Main.player[Main.myPlayer];          
            if(player.ownedProjectileCounts[mod.ProjectileType("YuumiMinion")] < 1)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, mod.ProjectileType("YuumiMinion"), 0, 0, player.whoAmI);
            }
            
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 15;
			knockback = 2f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) 
        {
			projType = mod.ProjectileType("ProwlingProjectile");
			attackDelay = 6;
		}

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}



    }
}