﻿using System;
using System.Collections.Generic;

namespace Nohros.Extensions
{
  public static class ProviderOptions
  {
    /// <summary>
    /// Checks if the specified options keys exists in the options dictionary.
    /// </summary>
    /// <param name="options">
    /// A <see cref="IDictionary{TKey,TValue}"/> to check for key existence.
    /// </param>
    /// <param name="keys">
    /// THe options keys to check for existence.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="options"/> is a null reference.
    /// </exception>
    /// <returns>
    /// <c>true</c> if all the specified keys exists in the given 
    /// <paramref name="options"/> dictionary; otherwise, <c>false</c>. If no
    /// keys is specified this method returns <c>true</c>.
    /// </returns>
    /// <remarks>
    /// This method checks for existence for each specified key and if one
    /// of them does not exists returns <c>false</c>.
    /// </remarks>
    public static bool ContainsKeys(this IDictionary<string, string> options,
      params string[] keys) {
      if (options == null) {
        throw new ArgumentNullException("options");
      }

      if (keys == null || keys.Length == 0) {
        return true;
      }

      for (int i = 0, j = keys.Length; i < j; i++) {
        if (!options.ContainsKey(keys[i])) {
          return false;
        }
      }
      return true;
    }

    /// <summary>
    /// Gets the string value associated with the specified key.
    /// </summary>
    /// <param name="options">
    /// A <see cref="IDictionary{TKey,TValue}"/> to search for
    /// <paramref name="key"/>.
    /// </param>
    /// <param name="key">
    /// The key of the value to get.
    /// </param>
    /// <param name="default_value">
    /// The value to be returned if the <paramref name="key"/> is not found.
    /// </param>
    /// <returns>
    /// A string containing the value for the specified option key, or the
    /// value of <paramref name="default_value"/> if <paramref name="key"/>
    /// is not found.
    /// </returns>
    public static string TryGetString(this IDictionary<string, string> options,
      string key, string default_value) {
      string value;
      if (!options.TryGetValue(key, out value)) {
        return default_value;
      }
      return value;
    }

    /// <summary>
    /// Gets the string value associated with the key
    /// <paramref name="key"/> and try to convert it to its 32-bit signed
    /// integer equivalent.
    /// </summary>
    /// <param name="options">
    /// A <see cref="IDictionary{TKey,TValue}"/> to get the value from.
    /// </param>
    /// <param name="key">
    /// The key that is associated with the value to get.
    /// </param>
    /// <param name="default_value">
    /// A 32-bit integer that will be returned when the key
    /// <paramref name="key"/> is not found.
    /// </param>
    /// <returns>
    /// The value associated with the key <paramref name="key"/> or
    /// <paramref name="default_value"/> if the key was not found.
    /// </returns>
    public static int TryGetInteger(this IDictionary<string, string> options,
      string key, int default_value) {
      string option;
      if (options.TryGetValue(key, out option)) {
        int i;
        if (int.TryParse(option, out i)) {
          return i;
        }
      }
      return default_value;
    }

    /// <summary>
    /// Gets the string value associated with the key
    /// <paramref name="key"/> and try to convert it to its 64-bit signed
    /// integer equivalent.
    /// </summary>
    /// <param name="options">
    /// A <see cref="IDictionary{TKey,TValue}"/> to get the value from.
    /// </param>
    /// <param name="key">
    /// The key that is associated with the value to get.
    /// </param>
    /// <param name="default_value">
    /// A 64-bit integer that will be returned when the key
    /// <paramref name="key"/> is not found.
    /// </param>
    /// <returns>
    /// The value associated with the key <paramref name="key"/> or
    /// <paramref name="default_value"/> if the key was not found.
    /// </returns>
    public static long TryGetLong(this IDictionary<string, string> options,
      string key, long default_value) {
      string option;
      if (options.TryGetValue(key, out option)) {
        int i;
        if (int.TryParse(option, out i)) {
          return i;
        }
      }
      return default_value;
    }
  }
}
