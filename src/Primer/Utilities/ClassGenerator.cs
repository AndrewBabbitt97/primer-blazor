using System;
using System.Collections.Generic;
using System.Linq;

namespace Primer.Utilities
{
    /// <summary>
    /// A CSS class generator
    /// </summary>
    public class ClassGenerator
    {
        /// <summary>
        /// The class map
        /// </summary>
        private readonly Dictionary<Func<string>, Func<bool>> _map = new Dictionary<Func<string>, Func<bool>>();

        /// <summary>
        /// The set of classes made by the generator
        /// </summary>
        public string Class => string.Join(" ", _map.Where(i => i.Value()).Select(i => i.Key()));

        /// <summary>
        /// Adds a class to the generator
        /// </summary>
        /// <param name="name">The class name</param>
        /// <returns>The class generator</returns>
        public ClassGenerator Add(string name)
        {
            _map.Add(() => name, () => true);
            return this;
        }

        /// <summary>
        /// Adds the class if a condition is met
        /// </summary>
        /// <param name="name">The name of the class</param>
        /// <param name="condition">The condition to be met</param>
        /// <returns>The class generator</returns>
        public ClassGenerator AddIf(string name, Func<bool> condition)
        {
            _map.Add(() => name, condition);
            return this;
        }

        /// <summary>
        /// Clears the class generator
        /// </summary>
        /// <returns></returns>
        public ClassGenerator Clear()
        {
            _map.Clear();
            return this;
        }
    }
}
