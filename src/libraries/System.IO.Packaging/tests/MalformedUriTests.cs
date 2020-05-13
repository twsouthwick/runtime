// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;

namespace System.IO.Packaging.Tests
{
    public class MalformedUriTests : FileCleanupTestBase
    {
        [Fact]
        public void MalformedHyperlinkThrows()
        {
            using (var package = Package.Open("malformed_hyperlink.xlsx"))
            {
                var part = package.GetPart(new Uri("/xl/worksheets/sheet1.xml", UriKind.Relative));
                Assert.Throws<UriFormatException>(() => part.GetRelationships());
            }
        }

        [Fact]
        public void MalformedHyperlinkHandle()
        {
            const string ExpectedUri = "mailto:mailto@one@";
            var settings = new PackageSettings
            {
                UriFactory = new MalformedUriFactory()
            };

            using (var package = Package.Open("malformed_hyperlink.xlsx", settings))
            {
                var part = package.GetPart(new Uri("/xl/worksheets/sheet1.xml", UriKind.Relative));
                var relationship = Assert.Single(part.GetRelationships());

                var malformed = Assert.IsType<MalformedUri>(relationship.TargetUri);
                Assert.Equal(ExpectedUri, malformed.Uri);
            }
        }

        [Fact]
        public void MalformedHyperlinkRoundtrip()
        {
            const string InvalidUri = "mailto:mailto@one@";

            var settings = new PackageSettings
            {
                UriFactory = new MalformedUriFactory(),
                PackageMode = FileMode.OpenOrCreate,
                PackageAccess = FileAccess.ReadWrite
            };

            using (var stream = new MemoryStream())
            {
                using (var package = Package.Open(stream, settings))
                {
                    Assert.Empty(package.GetRelationships());
                    package.CreateRelationship(new MalformedUri(InvalidUri), TargetMode.External, "relationship");
                }

                using (var package = Package.Open(stream, settings))
                {
                    var relationship = Assert.Single(package.GetRelationships());
                    var malformed = Assert.IsType<MalformedUri>(relationship.TargetUri);
                    Assert.Equal(InvalidUri, malformed.Uri);
                }
            }
        }

        private class MalformedUriFactory : IUriFactory
        {
            public Uri CreateUri(string url, UriKind kind)
            {
                if (Uri.TryCreate(url, kind, out var result))
                {
                    return result;
                }

                return new MalformedUri(url);
            }

            public string GetOriginalString(Uri uri)
            {
                if (uri is MalformedUri malformed)
                {
                    return malformed.Uri;
                }

                return uri.OriginalString;
            }
        }

        internal class MalformedUri : Uri
        {
            public MalformedUri(string uriString)
                : base("http://unknown")
            {
                Uri = uriString;
            }

            public string Uri { get; }

            public override string ToString() => Uri;
        }
    }
}
