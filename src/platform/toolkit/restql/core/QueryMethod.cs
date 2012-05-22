﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Nohros.Toolkit.RestQL
{
  public enum QueryMethod
  {
    /// <summary>
    /// This is the default method of the <see cref="Query"/> class and
    /// informs the query processor that the query should return a value.
    /// </summary>
    Get = 0,

    /// <summary>
    /// The SET method is used to modify(add, insert, delete) and entity.
    /// Queries that use this method should not return any data except the
    /// number of modification that was performed.
    /// </summary>
    Set = 1
  }
}
