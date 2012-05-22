﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Nohros.Data.Providers
{
  /// <summary>
  /// A implementation of the <see cref="IConnectionProvider"/> that
  /// provides connections for the Microsoft Sql Server.
  /// </summary>
  public partial class SqlConnectionProvider : IConnectionProvider
  {
    const string kConnectionStringOption = "connection-string";
    const string kServerOption = "server";
    const string kLoginOption = "login";
    const string kPasswordOption = "password";
    const string kDefaultSchema = "dbo";

    readonly string connection_string_;
    readonly string schema_;

    #region .ctor
    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="SqlConnectionProvider"/> class using the specified
    /// connection string.
    /// </summary>
    public SqlConnectionProvider(string connection_string)
      : this(connection_string, kDefaultSchema) {
    }

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="SqlConnectionProvider"/> class using the specified
    /// connection string and database schema.
    /// </summary>
    public SqlConnectionProvider(string connection_string, string schema) {
      connection_string_ = connection_string;
      schema_ = schema;
    }
    #endregion

    #region IConnectionProvider Members
    /// <inheritdoc/>
    IDbConnection IConnectionProvider.CreateConnection() {
      return CreateConnection();
    }

    /// <summary>
    /// Gets the schema to be used by the connection created by this class.
    /// </summary>
    /// <remarks>
    /// If a schema is not specified, this methos will return the string "dbo".
    /// </remarks>
    public string Schema {
      get { return schema_; }
    }
    #endregion

    /// <summary>
    /// Creates a new instance of the <see cref="SqlConnection"/> class using
    /// the provider connection string.
    /// </summary>
    /// <returns>
    /// A instance of the <see cref="SqlConnection"/> class.
    /// </returns>
    public SqlConnection CreateConnection() {
      return new SqlConnection(connection_string_);
    }
  }
}