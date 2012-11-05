﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolygonConverter.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the PolygonConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GeoJSON.Net.Converters
{
    using System;

    using GeoJSON.Net.Geometry;

    using Newtonsoft.Json;

    /// <summary>
    /// Converter to read and write the <see cref="MultiPolygon" /> type.
    /// </summary>
    public class PolygonConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
			writer.WriteStartArray();
			var g = value as List<LineString>;
	        var bigStringBuilder = new StringBuilder();
			foreach (var lineString in g)
			{
				var sb = new StringBuilder();
	       
			foreach (var position in lineString.Coordinates)
			{
				var p = position as GeographicPosition;
				sb.AppendFormat("[{1},{0}],", p.Latitude.ToString(CultureInfo.InvariantCulture), p.Longitude.ToString(CultureInfo.InvariantCulture));
			}
			var s = sb.ToString();
			s = s.Remove(s.Length - 1);
				bigStringBuilder.AppendFormat("[{0}],", s);
			}

			var result = bigStringBuilder.ToString();
			result = result.Remove(result.Length - 1);
			writer.WriteRawValue(result);
			writer.WriteEndArray();
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // ToDo: implement
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Polygon);
        }
    }
}
