/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using System.Net.NetworkInformation;

namespace SharpGlue.Core
{
    /// <summary>
    /// Represents a game object.
    /// </summary>
    public class GameObject
    {
        string name;
        object tag;
        Vector2 position = new Vector2(0, 0);
        Size size = new Size(0, 0);

        /// <summary>
        /// Returns an empty game object.
        /// </summary>
        public static GameObject Empty = new();

        /// <summary>
        /// Gets or sets the position of this <see cref="GameObject"/>
        /// </summary>
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        /// <summary>
        /// Gets or sets the size of this <see cref="GameObject"/>
        /// </summary>
        public Size Size
        {
            get => size;
            set => size = value;
        }

        /// <summary>
        /// Gets the name of this game object.
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// Gets or sets the tag of this <see cref="GameObject"/>
        /// </summary>
        public object Tag
        {
            get => tag;
            set => tag = value;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="GameObject"/>
        /// </summary>
        public GameObject() { }

        /// <summary>
        /// Moves this <see cref="GameObject"/>
        /// </summary>
        /// <param name="to">the next <see cref="Vector2"/> position.</param>
        public void Move( Vector2 to ) {
            position += to;
        }

        /// <summary>
        /// Moves this <see cref="GameObject"/>
        /// </summary>
        public void Move( float x, float y ) {
            position.X += x;
            position.Y += y;
        }

        /// <summary>
        /// Inflates this size.
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        /// <returns></returns>
        public void Inflate( int horizontal, int vertical ) {
            size.Width += horizontal * 2;
            size.Height += vertical * 2;
        }

        /// <summary>
        /// Gets a bool value indercating whether this <see cref="GameObject"/> interacts with other <see cref="GameObject"/> position.
        /// </summary>
        /// <param name="with">The <see cref="GameObject"/></param>
        /// <returns></returns>
        public bool Interact( GameObject with ) {
            var newRect = new Rectangle((int)position.X, (int)position.Y, size.Width, size.Height);
            var withRect = new Rectangle((int)with.Position.X, (int)with.Position.Y, with.Size.Width, with.Size.Height);

            return newRect.Interact(withRect);
        }

        #region static methods
        /// <summary>
        /// Find a <see cref="GameObject"/>, with the specific name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><see cref="GameObject"/></returns>
        public static GameObject FindGameObject(string name) {
            GameObject obj = null;
            foreach (var o in GameObjectCollection.objects)
                if (o.Name == name)
                    obj = o;
            return obj;
        }

        /// <summary>
        /// Finds a <see cref="GameObject"/> by its type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FindGameObjectByType<T>() where T: GameObject {
            foreach(var obj in GameObjectCollection.objects) {
                if (obj is T)
                    return (T)obj;
            }
            return (T)null;
        }
        #endregion
    }
}
