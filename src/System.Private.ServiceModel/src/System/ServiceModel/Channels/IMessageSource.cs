// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


using System.Threading.Tasks;

namespace System.ServiceModel.Channels
{
    public interface IMessageSource
    {
        Task<Message> ReceiveAsync(TimeSpan timeout);
        Message Receive(TimeSpan timeout);

        Task<bool> WaitForMessageAsync(TimeSpan timeout);
        bool WaitForMessage(TimeSpan timeout);
    }
}
