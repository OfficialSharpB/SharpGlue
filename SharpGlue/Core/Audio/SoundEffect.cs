/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using SFML.Audio;

using SharpGlue.Base;

namespace SharpGlue.Core.Audio
{
    /// <summary>
    /// Represents a sound effect.
    /// </summary>
    public class SoundEffect : ILoadableContent
    {
        string path;
        SoundBuffer buffer;
        Sound sound;

        public string Path => path;

        public string Name => System.IO.Path.GetFileNameWithoutExtension(path);

        /// <summary>
        /// Gets or sets whether the current <see cref="SoundEffect"/> should loop, after finishing.
        /// </summary>
        public bool Loop
        {
            get => sound.Loop;
            set => sound.Loop = value;
        }

        /// <summary>
        /// Gets or sets the volume of this sound.
        /// </summary>
        public float Volume
        {
            get => sound.Volume;
            set => sound.Volume = value;
        }

        /// <summary>
        /// Gets or sets the pitch of this sound.
        /// </summary>
        public float Pitch
        {
            get => sound.Pitch;
            set => sound.Pitch = value;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="SoundEffect"/>
        /// </summary>
        /// <param name="path"></param>
        public SoundEffect(string path) {
            this.path = path;
            buffer = new SoundBuffer(path);
            sound = new Sound(buffer);
        }

        /// <summary>
        /// Plays the current sound effect.
        /// </summary>
        public void Play() => sound.Play();

        /// <summary>
        /// Stops playing.
        /// </summary>
        public void Stop() => sound.Stop();

        /// <summary>
        /// Pause the sound.
        /// </summary>
        public void Pause() => sound.Pause();

        /// <summary>
        /// Restart.
        /// </summary>
        public void Restart() {
            sound.Stop();
            sound.Play();
        }
    }
}
