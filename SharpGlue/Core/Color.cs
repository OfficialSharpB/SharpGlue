/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/

using System;

namespace SharpGlue.Core
{
    /// <summary>
    /// Represents a 32bit color.
    /// </summary>
    public class Color
    {
        int r, g, b, a;

        /// <summary>
        /// Gets the red color.
        /// </summary>
        public int R { get => r; }

        /// <summary>
        /// Gets the green color.
        /// </summary>
        public int G { get => g; }

        /// <summary>
        /// Gets the blue color.
        /// </summary>
        public int B { get => b; }

        /// <summary>
        /// Gets the alpha color.
        /// </summary>
        public int A { get => a; }

        /// <summary>
        /// Initialize a new instance of <see cref="Color"/>
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public Color(int r, int g, int b, int a) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Color"/>
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public Color(int r, int g, int b) : this(r, g, b, 255) { }

        public static Color Black = new Color(0, 0, 0);
        public static Color White = new Color(255, 255, 255);
        public static Color ConflowerBlue = new Color(39, 58, 93);
    }

    public static class ColorConverter
    {
        /// <summary>
        /// Convert <see cref="SFML.Graphics.Color"/> to <see cref="SharpGlue.Core.Color"/>
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static SFML.Graphics.Color ToSFML(Color color) {
            return new SFML.Graphics.Color((byte)color.R, (byte)color.G, (byte)color.B, (byte)color.A);
        }

        /// <summary>
        /// Get a color from hexidecimal #hhd
        /// </summary>
        /// <param name="htmlColor"></param>
        /// <returns></returns>
        public static Color FromHex(string hexColor) {
            if (hexColor[0] == '#' && hexColor.Length == 4) {
                char r = hexColor[1], g = hexColor[2], b = hexColor[3];
                hexColor = new string(new char[] { '#', r, r, g, g, b, b });
            }

            // #aabbcc
            if (hexColor[0] == '#' && hexColor.Length == 7) {
                int r = Convert.ToInt32(hexColor.Substring(1, 2), 16);
                int g = Convert.ToInt32(hexColor.Substring(3, 2), 16);
                int b = Convert.ToInt32(hexColor.Substring(5, 2), 16);
                return new Color(r, g, b);
            }

            // #xxaabbcc
            if (hexColor[0] == '#' && hexColor.Length == 9) {
                int a = Convert.ToInt32(hexColor.Substring(1, 2), 16);
                int r = Convert.ToInt32(hexColor.Substring(3, 2), 16);
                int g = Convert.ToInt32(hexColor.Substring(5, 2), 16);
                int b = Convert.ToInt32(hexColor.Substring(7, 2), 16);
                return new Color(a, r, g, b);
            }

            return new Color(0, 0, 0);
        }
    }
}
