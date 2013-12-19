using System;

namespace PingPongPro.Domain
{
    public static class SystemGuid
    {
        public static Func<Guid> New = () => Guid.NewGuid();
    }
}