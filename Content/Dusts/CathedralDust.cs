using Terraria;
using Terraria.Utilities;
using Terraria.ModLoader;
using System;
using skybound.Core;

namespace skybound.Content.Dusts
{
    public class CathedralDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale *= 0.7f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.velocity.Y += 0.2f;
            if (Main.tile[(int)dust.position.X / 16, (int)dust.position.Y / 16].HasTile && Main.tile[(int)dust.position.X / 16, (int)dust.position.Y / 16].BlockType == Terraria.ID.BlockType.Solid && Main.tileSolid[Main.tile[(int)dust.position.X / 16, (int)dust.position.Y / 16].TileType])
                dust.velocity *= -0.5f;
            dust.rotation = dust.velocity.ToRotation();
            dust.scale *= 0.99f;
            if (dust.scale < 0.2f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}