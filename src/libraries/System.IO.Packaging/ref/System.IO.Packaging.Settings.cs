// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// ------------------------------------------------------------------------------
// Changes to this file must follow the https://aka.ms/api-review process.
// ------------------------------------------------------------------------------

namespace System.IO.Packaging
{
    public abstract partial class Package : System.IDisposable
    {
        protected Package(PackageSettings settings) { }
        public static System.IO.Packaging.Package Open(System.IO.Stream stream, PackageSettings settings) { throw null; }
        public static System.IO.Packaging.Package Open(string path, PackageSettings settings) { throw null; }
    }

    public partial class PackageSettings
    {
        public FileMode PackageMode { get { throw null; } set { throw null; } }
        public FileAccess PackageAccess { get { throw null; } set { throw null; } }
        public FileShare PackageShare { get { throw null; } set { throw null; } }
        public IUriFactory UriFactory { get { throw null; } set { throw null; } }
    }

    public interface IUriFactory
    {
        System.Uri CreateUri(string url, System.UriKind kind);
        string GetOriginalString(System.Uri uri);
    }

    public class DefaultUriFactory : IUriFactory
    {
        public static IUriFactory Instance => throw null;

        protected DefaultUriFactory() { }

        public virtual Uri CreateUri(string url, UriKind kind) => throw null;

        public virtual string GetOriginalString(Uri uri) => throw null;
    }
}
