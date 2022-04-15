/*
 * SharpBoy - a cross platform application made to support games for sfml using this engine, 
 * aswell as emulator plugins.
 * 
 * Developer: StephenFox.
 * Website: sharpboy.org.
*/
using System.ComponentModel;

namespace SharpGlue.Core
{
    public class GameContext
    {
        uint depth = 0;
        uint stencil = 0;
        uint antialiasing = 0;

        /// <summary>
        /// Gets or sets the depth width/bits.
        /// </summary>
        [DefaultValue(0)]
        public uint DepthBits
        {
            get => depth;
            set => depth = value;
        }

        /// <summary>
        /// Gets or sets the stencil.
        /// </summary>
        [DefaultValue(0)]
        public uint Stencil
        {
            get => stencil;
            set => stencil = value;
        }

        /// <summary>
        /// Gets or sets the antialiasing level.
        /// </summary>
        [DefaultValue(0)]
        public uint Antialiasing
        {
            get => antialiasing;
            set => antialiasing = value;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="GameContext"/>
        /// </summary>
        /// <param name="depth">The depth of the window.</param>
        /// <param name="stencil">The stencil.</param>
        /// <param name="antialiasing">The level of antialiasing.</param>
        public GameContext(uint depth, uint stencil, uint antialiasing) {
            this.depth = depth;
            this.stencil = stencil;
            this.antialiasing = antialiasing;
        }
    }
}
