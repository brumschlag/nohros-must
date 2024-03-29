﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;

namespace Nohros.Dynamics
{
  internal static class Dynamics_
  {
    const string kDynamicAssemblyName = "Nohros.Dynamics";

    static readonly ModuleBuilder module_;
    static readonly IDictionary<string, MethodInfo> data_reader_methods_;
#if DEBUG
    static readonly AssemblyBuilder assembly_;
#endif

    #region .ctor
    static Dynamics_() {
      AppDomain app = AppDomain.CurrentDomain;
      AssemblyName asm_name = new AssemblyName();
      asm_name.Name = kDynamicAssemblyName;

      // define that the method is allowed to acess non-public members.
      /*Type permission = typeof(ReflectionPermissionAttribute);
      ConstructorInfo ctor =
        permission
          .GetConstructor(new[] { typeof(SecurityAction) });
      PropertyInfo access = permission.GetProperty("Flags");
      var reflection_permission_attribute =
        new CustomAttributeBuilder(ctor, new object[] { SecurityAction.Demand },
          new[] { access },
          new object[] {
            ReflectionPermissionFlag.MemberAccess |
              ReflectionPermissionFlag.RestrictedMemberAccess
          });*/
#if DEBUG
      AssemblyBuilder asm_builder = app
        .DefineDynamicAssembly(asm_name, AssemblyBuilderAccess.RunAndSave);
      assembly_ = asm_builder;
      module_ = asm_builder
        .DefineDynamicModule(asm_builder.GetName().Name,
          "nohros.dynamics.dll");
#else
      AssemblyBuilder assembly = app
        .DefineDynamicAssembly(asm_name, AssemblyBuilderAccess.Run);
          //new[] {reflection_permission_attribute});
      module_ = assembly
        .DefineDynamicModule(assembly.GetName().Name, false);
#endif
      data_reader_methods_ = new Dictionary<string, MethodInfo>();
    }
    #endregion

#if DEBUG
    public static AssemblyBuilder AssemblyBuilder {
      get { return assembly_; }
    }
#endif

    /// <summary>
    /// Checks if a dynamic type exists for the type <paramref name="type"/>
    /// and prefix <paramref name="prefix"/>.
    /// </summary>
    /// <returns></returns>
    public static bool DynamicTypeExists(string prefix, Type type) {
      return module_.GetType(GetDynamicTypeName(prefix, type)) != null;
    }

    /// <summary>
    /// Gets the name of the dynamic type for the <typeparamref name="type"/>.
    /// </summary>
    /// <param name="type">
    /// The type which dynamic type name should be retrieved.
    /// </param>
    /// <returns></returns>
    public static string GetDynamicTypeName(Type type) {
      return GetDynamicTypeName(type.Namespace, type);
    }

    /// <summary>
    /// Gets the name of the dynamic type for the <typeparamref name="type"/>.
    /// </summary>
    /// <param name="prefix">
    /// The preffix to be prepended on the type name.
    /// </param>
    /// <param name="type">
    /// The type which dynamic type name should be retrieved.
    /// </param>
    /// <param name="suffix">
    /// The suffix to be appended to the type name.
    /// </param>
    /// <returns></returns>
    public static string GetDynamicTypeName(string prefix, Type type,
      string suffix = "") {
      string type_name = type.Name;
      if (type.IsInterface) {
        if (type_name[0] == 'I' || type_name[0] == 'i') {
          type_name = type_name.Substring(1, type_name.Length - 1);
        }
      }
      return prefix + "." + type_name + suffix;
    }

    public static string GetDataReaderMethodName(Type type) {
      // If the type is a enumeration we need to get the method that is
      // associated with the enumeration underlying type.
      if (type.IsEnum) {
        type = Enum.GetUnderlyingType(type);
      }

      if (type == typeof (int)) {
        return "GetInt32";
      }
      if (type == typeof (string)) {
        return "GetString";
      }
      if (type == typeof (DateTime)) {
        return "GetDateTime";
      }
      if (type == typeof (bool)) {
        return "GetBoolean";
      }
      if (type == typeof (decimal)) {
        return "GetDecimal";
      }
      if (type == typeof (long)) {
        return "GetInt64";
      }
      if (type == typeof (Guid)) {
        return "GetGuid";
      }
      if (type == typeof (float)) {
        return "GetFloat";
      }
      if (type == typeof (double)) {
        return "GetDouble";
      }
      if (type == typeof (char)) {
        return "GetChar";
      }
      if (type == typeof (byte)) {
        return "GetByte";
      }
      if (type == typeof (short)) {
        return "GetInt16";
      }
      if (type == typeof (TimeSpan)) {
        return "GetTimeSpan";
      }
      throw new ArgumentException(
        string
          .Format(Resources.Resources.Arg_WrongType, type.Name, "ValueType"));
    }

    internal static MethodInfo GetDataReaderMethod(string method,
      Type derived = null) {
      MethodInfo method_info = null;
      //if (!data_reader_methods_.TryGetValue(method, out method_info)) {

      // If derived was specified the chance that 
      if (derived != null) {
        method_info = derived.GetMethod(method);
      }

      // Most of the IDataReader method is inherited from the IDataRecord
      // interface. We have more probability to found the requested
      // method on the IDataRecord interface than in the IDataReader
      // interface.
      return method_info ??
        typeof (IDataRecord).GetMethod(method) ??
          typeof (IDataReader).GetMethod(method);
      //}
      //return method_info;
    }

#if DEBUG
    public static void Save(string file_name) {
      assembly_.Save(file_name);
    }
#endif

    public static ModuleBuilder ModuleBuilder {
      get { return module_; }
    }

    public static IDictionary<string, MethodInfo> DataReaderMethods {
      get { return data_reader_methods_; }
    }
  }
}
