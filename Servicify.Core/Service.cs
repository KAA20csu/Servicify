﻿namespace Servicify.Core;

public class Service : IIdentityEntity
{
    private Service()
    {
    }

    public Service(string name, string description, long organizationId, List<Appointment> appointments)
    {
        Name = name;
        Description = description;
        OrganizationId = organizationId;
        Appointments = appointments;
        Subscribers = new List<Client>();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
    public List<Appointment> Appointments { get; set; }
    public List<AvailableTime> AvailableTimes { get; set; }
    public List<Client> Subscribers { get; set; }
    public long Id { get; set; }
}