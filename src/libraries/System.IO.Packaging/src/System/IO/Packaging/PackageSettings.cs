// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.IO.Packaging
{
    public class PackageSettings
    {
        public FileMode PackageMode { get; set; } = FileMode.Open;

        public FileAccess PackageAccess { get; set; } = FileAccess.Read;

        public FileShare PackageShare { get; set; } = FileShare.None;

        public IUriFactory UriFactory { get; set; } = DefaultUriFactory.Instance;
    }
}
