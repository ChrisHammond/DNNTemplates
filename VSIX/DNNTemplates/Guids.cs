// Guids.cs
// MUST match guids.h
using System;

namespace Christoc.DNNTemplates
{
    static class GuidList
    {
        public const string guidDNNTemplatesPkgString = "e48e838a-c708-4d43-b822-4d5de0d13eed";
        public const string guidDNNTemplatesCmdSetString = "722c6466-60bf-48af-98c3-c99fd81f6d5b";

        public static readonly Guid guidDNNTemplatesCmdSet = new Guid(guidDNNTemplatesCmdSetString);
    };
}