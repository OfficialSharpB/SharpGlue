/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using System.Collections.Generic;

namespace SharpGlue.Core
{
    /// <summary>
    /// Represents a collection of <see cref="GameObject"/>s
    /// </summary>
    public class GameObjectCollection
    {
        internal static List<GameObject> objects = new();

        /// <summary>
        /// Gets the count or amount of objects inside this collection.
        /// </summary>
        public int Count => objects.Count;

        /// <summary>
        /// Initialize a new instance of <see cref="GameObjectCollection"/>
        /// </summary>
        public GameObjectCollection() { }

        /// <summary>
        /// Adds a <see cref="GameObject"/> to this collection.
        /// </summary>
        /// <param name="obj">The object to add.</param>
        public void Add( GameObject obj ) => objects.Add(obj);

        /// <summary>
        /// Remove a <see cref="GameObject"/> from this collection.
        /// </summary>
        /// <param name="obj">The object to remove.</param>
        public void Remove( GameObject obj ) => objects.Remove(obj);

        /// <summary>
        /// Gets a <see cref="GameObject"/> from this collection.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        /// <returns>A <see cref="GameObject"/> with the specified name.</returns>
        public GameObject this[string name]
        {
            get {
                GameObject obj = null;
                foreach (var o in objects)
                    if (o.Name == name)
                        obj = o;
                return obj;
            }
        }
    }
}
