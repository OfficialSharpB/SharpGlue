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
    /// Represents gametime.
    /// </summary>
    public class GameTime
    {
        float deltaTime, timeScale;
        TimeSpan totalEnlapsedTime;

        /// <summary>
        /// Initialize a new instance of <see cref="GameTime"/>
        /// </summary>
        public GameTime() {
            deltaTime = 0;
            totalEnlapsedTime = TimeSpan.FromSeconds(0);
        }

        /// <summary>
        /// Gets the delta time.
        /// </summary>
        public float DeltaTime => deltaTime * timeScale;

        /// <summary>
        /// Gets or sets the time scale.
        /// </summary>
        public float TimeScale
        {
            get => timeScale;
            set => timeScale = value;
        }

        /// <summary>
        /// Gets the enlapsed time.
        /// </summary>
        public TimeSpan Enlapsed
        {
            get => totalEnlapsedTime;
        }

        internal void update(TimeSpan enlapsed, float deltaTime, float timeScale) {
            this.deltaTime = deltaTime;
            this.totalEnlapsedTime = enlapsed;
            this.timeScale = timeScale;
        }
    }
}
