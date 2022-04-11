/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using System.Collections.Generic;

namespace SharpGlue.Core.Input
{
    public class InputSystem
    {
        List<AbstractInputMethod> inputs;

        /// <summary>
        /// Initialize a new instance of <see cref="InputSystem"/>
        /// </summary>
        public InputSystem() =>
            inputs = new List<AbstractInputMethod>();

        /// <summary>
        /// Adds a input method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputMethod"></param>
        public void AddInput<T>(T inputMethod) where T: AbstractInputMethod {
            inputs.Add(inputMethod);
        }

        /// <summary>
        /// Gets an input method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetInput<T>() where T: AbstractInputMethod {
            AbstractInputMethod ab = null;
            foreach (var input in inputs)
                if (input is T)
                    ab = (T)input;
            return (T)ab;
        }

        /// <summary>
        /// Update all inputs.
        /// </summary>
        public void Update() {
            for (int i = 0; i < inputs.Count; i++)
                inputs[i].Update();
        }
    }
}
