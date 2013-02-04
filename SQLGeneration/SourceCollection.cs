﻿using System;
using System.Collections.Generic;
using SQLGeneration.Properties;
using System.Globalization;

namespace SQLGeneration
{
    /// <summary>
    /// Holds all of the sources that occur within a SELECT statement.
    /// </summary>
    public class SourceCollection
    {
        private readonly Dictionary<string, AliasedSource> sourceLookup;

        /// <summary>
        /// Initializes a new instance of a SourceCollection.
        /// </summary>
        internal SourceCollection()
        {
            sourceLookup = new Dictionary<string, AliasedSource>(StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Initializes a new instance of a SourceCollection, copying the values
        /// from the given source collection.
        /// </summary>
        /// <param name="other">The source collection to copy the value from.</param>
        internal SourceCollection(SourceCollection other)
        {
            sourceLookup = new Dictionary<string, AliasedSource>(other.sourceLookup, StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Adds the given source, associating it with the given source name.
        /// </summary>
        /// <param name="sourceName">The name to associate with the source.</param>
        /// <param name="source">The source to add.</param>
        internal void AddSource(string sourceName, AliasedSource source)
        {
            if (sourceLookup.ContainsKey(sourceName))
            {
                string message = String.Format(CultureInfo.CurrentCulture, Resources.DuplicateSourceName, sourceName);
                throw new SQLGenerationException(message);
            }
            sourceLookup.Add(sourceName, source);
        }

        /// <summary>
        /// Adds all of the sources from the given collection to the current collection.
        /// </summary>
        /// <param name="other">The other source collection to add item from.</param>
        internal void AddSources(SourceCollection other)
        {
            foreach (KeyValuePair<string, AliasedSource> pair in other.sourceLookup)
            {
                AddSource(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Gets the source with the given name or alias.
        /// </summary>
        /// <param name="sourceName">The name or alias of the source.</param>
        /// <returns>The source with the given name or alias.</returns>
        public AliasedSource this[string sourceName]
        {
            get 
            {
                AliasedSource source;
                if (!sourceLookup.TryGetValue(sourceName, out source))
                {
                    throw new SQLGenerationException(Resources.UnknownSource);
                }
                return source;
            }
        }

        /// <summary>
        /// Gets whether a source exists with the given name.
        /// </summary>
        /// <param name="sourceName">The name of the source.</param>
        /// <returns>True if the source exists; otherwise, false.</returns>
        internal bool Exists(string sourceName)
        {
            return sourceLookup.ContainsKey(sourceName);
        }

        /// <summary>
        /// Removes the source with the given name.
        /// </summary>
        /// <param name="sourceName">The name of the source to remove.</param>
        /// <returns>True if the source is removed; otherwise, false.</returns>
        internal bool Remove(string sourceName)
        {
            return sourceLookup.Remove(sourceName);
        }
    }
}