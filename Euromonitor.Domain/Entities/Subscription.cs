﻿namespace Euromonitor.Domain.Entities;
public class Subscription
{
    public int Id { get; set; } 
    public int UserId { get; set; }
    public User User { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public DateTime SubscribedOn { get; set; }
}
