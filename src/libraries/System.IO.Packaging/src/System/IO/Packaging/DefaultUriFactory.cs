// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.IO.Packaging
{
    public class DefaultUriFactory : IUriFactory
    {
        public static IUriFactory Instance { get; } = new DefaultUriFactory();

        protected DefaultUriFactory()
        {
        }

        public virtual Uri CreateUri(string url, UriKind kind) => new Uri(url, kind);

        public virtual string GetOriginalString(Uri uri) => uri.OriginalString;
    }
}
