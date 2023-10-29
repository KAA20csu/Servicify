﻿namespace Servicify.Core
{
    public class AvailableTime : IIdentityEntity
    {
        public long Id { get; set; }
        public long ServiceID { get; set; }
        public Service Service { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        private AvailableTime()
        {

        }
    }
}
