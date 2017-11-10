using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine2D.Components
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RequiredComponent : Attribute
    {
        internal bool IsExactType;

        public RequiredComponent() : this(true)
        {
        }

        public RequiredComponent(bool isExactType)
        {
            this.IsExactType = isExactType;
        }
        
    }
}