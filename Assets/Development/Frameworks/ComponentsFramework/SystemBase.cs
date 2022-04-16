using System.Collections.Generic;
using Frameworks.ComponentsFramework.Interfaces;

namespace Frameworks.ComponentsFramework
{
    public abstract class SystemBase : IInitializable
    {
        protected List<ComponentBase> Components = new ();

        protected void AddComponent(ComponentBase component)
        {
            Components.Add(component);
        }

        public virtual void Initialize(bool forced)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                if (Components[i] is IInitializable initializable)
                {
                    initializable.Initialize(false);
                }
            }
        }
    }
}