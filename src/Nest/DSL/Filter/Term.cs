﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Nest.Resolvers;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Nest.Resolvers.Converters;

namespace Nest
{
	[JsonConverter(typeof(CustomJsonConverter))]
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class TermFilter : BaseFilter, ICustomJson
	{
		internal PropertyPathMarker Field { get; set; }
		internal object Value { get; set; }
		internal double? Boost { get; set; }

		internal bool IsConditionless { get { return this.Value == null || this.Value.ToString().IsNullOrEmpty() || this.Field.IsConditionless(); } }	
		object ICustomJson.GetCustomJson()
		{
			return new Dictionary<object, object>
			{
				{
					Field, new Dictionary<string, object>
					{
						{ "value", Value },
						{ "boost", Boost },
					}
				}
			};
		}
	}
}
