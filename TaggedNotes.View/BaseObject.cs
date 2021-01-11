using System;
using System.Collections.Generic;
using System.Text;

using TaggedNotes.Interfaces;

namespace TaggedNotes.View
{
    /// <summary>
    /// Base object realization
    /// </summary>
    abstract class BaseObject : IBaseObject
    {
        #region IBaseObject contract
        public int Id { get; set; }
        #endregion
    }
}