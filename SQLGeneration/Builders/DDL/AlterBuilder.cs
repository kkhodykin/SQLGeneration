﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGeneration.Builders
{
  
    /// <summary>
    /// The alter builder. Used to build "ALTER" statements.
    /// </summary>
    public class AlterBuilder : IAlterBuilder
    {
        private bool _hasTerminator = false;
        /// <summary>
        /// Whether or not this statement is terminated with a sql terminator.
        /// </summary>
        public bool HasTerminator
        {
            get
            {
                return _hasTerminator;
            }
            set
            {
                _hasTerminator = value;
            }
        }

        /// <summary>
        /// The database object to be created.
        /// </summary>
        public IDatabaseObject AlterObject { get; set; }

        void IVisitableBuilder.Accept(BuilderVisitor visitor)
        {
            visitor.VisitAlter(this);
        }
    }


}
