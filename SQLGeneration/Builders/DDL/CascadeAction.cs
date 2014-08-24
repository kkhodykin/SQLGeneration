﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{
    /// <summary>
    /// Foreign Key Cascade Action.
    /// </summary>
    public class CascadeAction : ForeignKeyAction
    {
        /// <summary>
        /// Provides information to the given visitor about the current builder.
        /// </summary>
        /// <param name="visitor">The visitor requesting information.</param>
        public override void Accept(BuilderVisitor visitor)
        {
            visitor.VisitForeignKeyCascadeAction(this);
        }
    }
}
