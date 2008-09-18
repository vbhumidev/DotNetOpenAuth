﻿//-----------------------------------------------------------------------
// <copyright file="MessagePartAttribute.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOAuth.Messaging {
	using System;
	using System.Net.Security;
	using System.Reflection;

	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	internal sealed class MessagePartAttribute : Attribute {
		private bool initialized;
		private string name;

		internal MessagePartAttribute() {
		}

		internal MessagePartAttribute(string name) {
			this.Name = name;
		}

		public string Name {
			get { return this.name; }
			set { this.name = string.IsNullOrEmpty(value) ? null : value; }
		}

		public ProtectionLevel Signed { get; set; }

		public bool Optional { get; set; }

		internal void Initialize(MemberInfo member) {
			if (member == null) {
				throw new ArgumentNullException("member");
			}

			if (!this.initialized) {
				if (String.IsNullOrEmpty(this.Name)) {
					this.Name = member.Name;
				}

				this.initialized = true;
			}
		}
	}
}
