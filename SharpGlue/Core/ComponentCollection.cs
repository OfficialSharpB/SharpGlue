/*
 * SharpBoy - a cross platform application made to support games for sfml using this engine, 
 * aswell as emulator plugins.
 * 
 * Developer: StephenFox.
 * Website: sharpboy.org.
*/
using SharpGlue.Base;

using System.Collections.Generic;

namespace SharpGlue.Core
{
    /// <summary>
    /// Represents a <see cref="List{T}"/> of <see cref="IComponents"/>
    /// </summary>
    public class ComponentCollection
    {
        List<IComponent> components;

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count
        {
            get => components.Count;
        }

        /// <summary>
        /// Gets or sets a component.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IComponent this[int index]
        {
            get => components[index];
            set => components[index] = value;
        }

        /// <summary>
        /// Initalize a new instance of <see cref="ComponentCollection"/>
        /// </summary>
        public ComponentCollection() =>
            components = new List<IComponent>();

        /// <summary>
        /// Adds a component.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        public void Add<T>(T component) where T: IComponent {
            component.DrawOrder = Count;
            components.Add(component);
        }

        /// <summary>
        /// Removes a component.
        /// </summary>
        /// <param name="index">The index of the component.</param>
        public void Remove(int index) {
            components.Remove(components[index]);
        }
    }
}
