// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.IO.Packaging
{
    public interface IUriFactory
    {
        Uri CreateUri(string url, UriKind kind);

        string GetOriginalString(Uri uri);
    }
}
