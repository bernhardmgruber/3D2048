using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Util
{
    class Color
    {
        private static Vector3D[] TILE_COLORS = new Vector3D[]
        {
            Color.rgb(0xeee4da), //2        2^1
            Color.rgb(0xede0c8), //4        2^2
            Color.rgb(0xf2b179), //8        2^3
            Color.rgb(0xf59563), //16       2^4
            Color.rgb(0xf67c5f), //32       2^5
            Color.rgb(0xf65e3b), //64       2^6
            Color.rgb(0xedcf72), //128      2^7
            Color.rgb(0xedcc61), //256      2^8
            Color.rgb(0xedc850), //512      2^9
            Color.rgb(0xedc53f), //1024     2^10
            Color.rgb(0xedc22e), //2048     2^11
        };

        private static Vector3D TILE_COLOR_SUPER = Color.rgb(0x3c3a32);

        public static Vector3D getTileColor(int value)
        {
            int index = (int) Math.Log(value, 2);
            if (index > 11)
            {
                return TILE_COLOR_SUPER;
            } else return TILE_COLORS[index-1];
        }

        public static Vector3D rgb(int hex)
        {
            int r = (hex >> 16) & 255;
            int g = (hex >> 8) & 255;
            int b = hex & 255;
            return new Vector3D(r/255, g/255, b/255);
        }
    }
}
