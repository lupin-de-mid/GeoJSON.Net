// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CRSBase.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the CRSBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GeoJSON.Net.CoordinateReferenceSystem
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Base class for all IGeometryObject implementing types
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class CRSBase : ICRSObject
    {
        /// <summary>
        /// Gets the type of the GeometryObject object.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CRSType Type { get; internal set; }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties", Required = Required.Always)]
        public Dictionary<string, object> Properties { get; internal set; }
    }
}
