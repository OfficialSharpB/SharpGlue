/*
 * SharpBoy - a cross platform application made to support games for sfml using this engine, 
 * aswell as emulator plugins.
 * 
 * Developer: StephenFox.
 * Website: sharpboy.org.
*/
using SharpGlue.Base;
using SharpGlue.Core.Exceptions;
using SharpGlue.Core.Graphics;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SharpGlue.Core.Content
{
    /// <summary>
    /// Represents a asset /and or content manager.
    /// </summary>
    public class ContentManager
    {
        Dictionary<IContent, String> loadedContences;

        /// <summary>
        /// used as a place holder, for where the content is located.
        /// </summary>
        string contentName = "content";

        //use for later use.
        ServiceContainer services;

        /// <summary>
        /// Gets the services.
        /// </summary>
        public ServiceContainer Services
        {
            get => services;
        }


        /// <summary>
        /// Gets or sets the name of the default folder, to witch this content loads assets from.
        /// </summary>
        public string Name
        {
            get => contentName;
            set => contentName = value;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="ContentManager"/>
        /// </summary>
        public ContentManager(ServiceContainer services) {
            this.loadedContences = new Dictionary<IContent, string>();
            this.services = services;
        }


        /// <summary>
        ///  Loads a <see cref="ILoadableContent"/> asset, into this <see cref="ContentManager"/>, if <typeparamref name="T"/> isn't a content type, then value returns null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public T Load<T>(string name) where T: ILoadableContent {
            var path = $@"{Environment.CurrentDirectory}\{contentName}\{name}";

            if (string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException("path: can not be null or empty");

            if (!File.Exists(path))
                throw new FileNotFoundException(path);

            ILoadableContent value = null;
            if(typeof(T) == typeof(Texture2D)) {
                var texture = new Texture2D(path);
                loadedContences.Add(texture, path);
                value = texture;
            }
            if(typeof(T) == typeof(SpriteFont)) {
                var spriteFont = new SpriteFont(path, 14);
                loadedContences.Add(spriteFont, path);
                value= spriteFont;
            }

            return (T)value;
        }

        /// <summary>
        /// Gets a <typeparamref name="T"/> from its specific name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">
        /// The name of the asset.
        /// <c>only supports the filename with out the extention or path.</c>
        /// </param>
        /// <returns>A <typeparamref name="T"/> type.</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ContentException"></exception>
        public T GetType<T>(string name) where T: IContent {

            if (string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException("name: can not be null or empty");

            if (!loadedContences.Values.Contains(name))
                throw new ContentException("Given name does not exist, or has yet to be loaded.");

            IContent content = null;
            foreach(var c in loadedContences.Keys) {
                if (c.Name == name)
                    content = (T)c;
            }
            return (T)content;
        }
    }
}
