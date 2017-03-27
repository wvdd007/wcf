﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Xml;

namespace System.ServiceModel
{
    public class SpnEndpointIdentity : EndpointIdentity
    {
        private static TimeSpan s_spnLookupTime = TimeSpan.FromMinutes(1);

        public SpnEndpointIdentity(string spnName) : base(spnName)
        {
            if (spnName == null)
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull(nameof(spnName));
        }

        public static TimeSpan SpnLookupTime
        {
            get
            {
                return s_spnLookupTime;
            }
            set
            {
                if (value.Ticks < 0)
                {
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(
                        new ArgumentOutOfRangeException(nameof(value), value.Ticks, SR.Format(SR.ValueMustBeNonNegative)));
                }
                s_spnLookupTime = value;
            }
        }

        internal override void WriteContentsTo(XmlDictionaryWriter writer)
        {
            if (writer == null)
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull(nameof(writer));

            writer.WriteElementString(XD.AddressingDictionary.Spn, XD.AddressingDictionary.IdentityExtensionNamespace, IdentityIdentifier?.ToString());
        }
    }
}